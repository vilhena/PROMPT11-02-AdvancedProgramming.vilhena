namespace DevLeap.Linq.ImagesStatus
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    using Mod02_AdvProgramming.LinqProvider.ImagesMetadata;
    using Mod02_AdvProgramming.LinqProvider.Linq;

    public class ImageQueryTranslator : ExpressionVisitor {
        ImageQueryParameters queryParameters;

        internal ImageQueryTranslator()
        {
        }

        internal ImageQueryParameters Translate(Expression expression)
        {
            this.queryParameters = new ImageQueryParameters();
            this.Visit(expression);
            return this.queryParameters;
        }

        // 
        // Listing 12-34
        // 
        /// <summary>
        /// These are the only supported extension methods (Where and Take)
        /// We simply visit the Where condition and the Take parameter
        /// and translate them into a ImagesStatus.QueryParameters instance
        /// </summary>
        protected override Expression VisitMethodCall(MethodCallExpression m)
        {
            if (m.Method.DeclaringType == typeof(Queryable))
            {
                switch (m.Method.Name)
                {
                    case "Where":
                        this.Visit(m.Arguments[0]);
                        LambdaExpression lambda = (LambdaExpression)StripQuotes(m.Arguments[1]);
                        this.Visit(lambda.Body);
                        return m;
                    case "Take":
                        this.Visit(m.Arguments[0]);
                        ConstantExpression constant = m.Arguments[1] as ConstantExpression;
                        if (constant == null)
                        {
                            throw new NotImplementedException("Take supported only for constant values");
                        }
                        queryParameters.MaxImages = GetIntConstant(constant);
                        return m;
                }
            }
            throw new NotSupportedException(string.Format("The method '{0}' is not supported", m.Method.Name));
        }
        private static Expression StripQuotes(Expression e)
        {
            while (e.NodeType == ExpressionType.Quote)
            {
                e = ((UnaryExpression)e).Operand;
            }
            return e;
        }


        protected override Expression VisitUnary(UnaryExpression u)
        {
            throw new NotSupportedException(
                string.Format(
                    "The unary operator '{0}' is not supported",
                    u.NodeType));
        }
        protected override Expression VisitConstant(ConstantExpression c)
        {
            if (c.Value is IQueryable)
            {
                // Assume constant nodes implementing IQueryable 
                // are Images enums
                return c;
            }
            throw new NotSupportedException(
                string.Format(
                    "The constant for '{0}' is not supported",
                    c.ToString()));
        }
        protected override Expression  VisitMember(MemberExpression m)
        {
            throw new NotSupportedException(
                string.Format(
                    "The member '{0}' is not supported",
                    m.Member.Name));
        }


        // 
        // Listing 12-35
        // 
        /// <summary>
        /// The AND condition simply continues the visit to the left and right parts
        /// If there is a binary operation other than a supported comparison,
        /// a NotSupportedException is thrown
        /// </summary>
        protected override Expression VisitBinary(BinaryExpression b)
        {
            switch (b.NodeType)
            {
                case ExpressionType.And:
                case ExpressionType.AndAlso:
                    // Compare only other binary operators - we default to AND, 
                    // so this is not an error and does not produce other effects
                    this.Visit(b.Left);
                    this.Visit(b.Right);
                    // We EXIT here, we do not process the condition further
                    return b;
                case ExpressionType.Equal:
                case ExpressionType.LessThanOrEqual:
                case ExpressionType.GreaterThanOrEqual:
                case ExpressionType.LessThan:
                case ExpressionType.GreaterThan:
                    return VisitBinaryComparison(b);
                default:
                    // We DO NOT support:
                    // - NotEqual
                    // - Or
                    throw new NotSupportedException(string.Format(
                        "The binary operator '{0}' is not supported", b.NodeType));
            }
        }

        // 
        // Listing 12-36
        // 
        /// <summary>
        /// Performs a sanity check of constant and memberAccess
        /// Then it performs a different translation according to 
        /// the type of the member to be compared with
        /// </summary>
        private Expression VisitBinaryComparison(BinaryExpression b)
        {
            // FIRST STEP
            // We support only a comparison between constant 
            // and a possible Images query parameter 
            ConstantExpression constant =
                (b.Left as ConstantExpression ?? b.Right as ConstantExpression);
            MemberExpression memberAccess =
                (b.Left as MemberExpression ?? b.Right as MemberExpression);

            // SECOND STEP
            // Sanity check of parameters
            if ((memberAccess == null) || (constant == null))
            {
                throw new NotSupportedException(
                    string.Format(
                        "The binary operator '{0}' must compare a valid Images attribute with a constant",
                        b.NodeType));
            }

            // We need to get the constant value
            if (constant.Value == null)
            {
                throw new NotSupportedException(
                    string.Format(
                        "NULL constant is not supported in binary operator {0}",
                        b.ToString()));
            }
            switch (Type.GetTypeCode(constant.Value.GetType()))
            {
                case TypeCode.String:
                case TypeCode.Int16:
                case TypeCode.Int32:
                case TypeCode.Double:
                    break;
                default:
                    throw new NotSupportedException(
                        string.Format(
                            "Constant {0} is of an unsupported type ({1})",
                            constant.ToString(),
                            constant.Value.GetType().Name));
            }

            // THIRD STEP
            // Look for member name through Reflection
            // We assume that string properties in Images have the same name 
            // in QueryParameters
            // We have a special check for Images members of complex types
            if (memberAccess.Member.ReflectedType == typeof(DateTime))
            {
                TranslateTimeSpanComparison(b.NodeType, constant, memberAccess);
                return b;
            }
            else if (memberAccess.Member.ReflectedType == typeof(CameraInformation))
            {
                TranslateCameraInformationComparison(constant, memberAccess);
                return b;
            }
            else if (memberAccess.Member.ReflectedType != typeof(ImageInformation))
            {
                throw new NotSupportedException(
                        string.Format(
                            "Member {0} is not of type Images",
                            memberAccess.ToString()));
            }
            TranslateStandardComparisons(b.NodeType, constant, memberAccess);
            return b;
        }

        /// <summary>
        /// The standard case supports an equal condition for strings
        /// and other comparisons for GroundSpeed and Altitude integers
        /// </summary>
        private void TranslateStandardComparisons(
            ExpressionType nodeType,
            ConstantExpression constant,
            MemberExpression memberAccess)
        {

            string stringFieldName =
                (from field in typeof(ImageInformation).GetProperties()
                 where Type.GetTypeCode(field.PropertyType) == TypeCode.String
                       && field.Name == memberAccess.Member.Name
                 select field.Name).FirstOrDefault();

            // Loop for all strings 
            if (stringFieldName != null)
            {
                if (nodeType != ExpressionType.Equal)
                {
                    throw new NotSupportedException(
                        string.Format(
                            "The binary operator '{0}' is not supported on {1} member",
                            nodeType,
                            memberAccess.Member.Name));
                }
                queryParameters.Filter.GetType()
                    .GetField(stringFieldName)
                    .SetValue(queryParameters.Filter, constant.Value);
            }
            else
            {
                // String not found
                switch (memberAccess.Member.Name)
                {
                    case "DateTaken":
                        //SetDateTimeParameter(
                        //    constant.Value.ToString(),
                        //    ref queryParameters.Filter.MinDateTaken,
                        //    ref queryParameters.Filter.MaxDateTaken,
                        //    nodeType);
                        //break;
                    default:
                        throw new NotSupportedException(
                            string.Format("Condition on member {0} is not supported",
                            memberAccess.ToString()));
                }
            }
        }

        // 
        // Listing 12-38
        // 
        /// <summary>
        /// We currently support only the Model and Manufacturer
        /// </summary>
        private void TranslateCameraInformationComparison(
            ConstantExpression constant,
            MemberExpression memberAccess)
        {

            MemberExpression parent = memberAccess.Expression as MemberExpression;
            if (parent.Member.ReflectedType != typeof(ImageInformation))
            {
                throw new NotSupportedException(string.Format("Member {0} is not of type ImageInformation",memberAccess));
            }
            // We support only ...
            if (parent.Member.Name == "Camera") {
                switch (memberAccess.Member.Name) {
                    case "Model":
                        queryParameters.Filter.CameraModel = constant.Value.ToString(); break;
                    case "Manufacturer":
                        queryParameters.Filter.CameraManufacturer = constant.Value.ToString(); break;
                    default:
                        throw new NotSupportedException(string.Format("Member {0} is not supported for type CameraInformation", memberAccess));
                }
            }
        }

        // 
        // Listing 12-38 (continue)
        // 
        /// <summary>
        /// We support only TotalMinutes and TotalHours comparison
        /// </summary>
        private void TranslateTimeSpanComparison(
            ExpressionType nodeType,
            ConstantExpression constant,
            MemberExpression memberAccess)
        {

            MemberExpression parent = memberAccess.Expression as MemberExpression;
            if (parent.Member.ReflectedType != typeof(ImageInformation))
            {
                throw new NotSupportedException(
                    string.Format(
                        "Member {0} is not of type Images",
                        memberAccess.ToString()));
            }

            // We support only TotalMinutes for this simple provider
            if ((memberAccess.Member.Name == "TotalMinutes")
                && (parent.Member.Name == "TimeToArrival"))
            {
                SetIntParameter(
                    (int)GetDoubleConstant(constant),
                    ref queryParameters.Filter.MaxDaysTaken,
                    ref queryParameters.Filter.MaxDaysTaken,
                    nodeType);
            }
            else 
            {
                throw new NotSupportedException(
                    string.Format(
                        "Query on {0} expression is not supported",
                        memberAccess.ToString()));
            }
        }

        internal static void SetIntParameter(
            int limit,
            ref int minValue,
            ref int maxValue,
            ExpressionType comparison) {
            switch (comparison)
            {
                case ExpressionType.Equal:
                    minValue = limit;
                    maxValue = limit;
                    break;
                case ExpressionType.LessThan:
                    maxValue = limit - 1;
                    break;
                case ExpressionType.LessThanOrEqual:
                    maxValue = limit;
                    break;
                case ExpressionType.GreaterThan:
                    minValue = limit + 1;
                    break;
                case ExpressionType.GreaterThanOrEqual:
                    minValue = limit;
                    break;
                default:
                    throw new NotSupportedException(
                        string.Format(
                            "The binary operator '{0}' is not supported",
                            comparison));
            }
        }
        internal static int GetIntConstant(ConstantExpression constant)
        {
            switch (Type.GetTypeCode(constant.Value.GetType()))
            {
                case TypeCode.Int16:
                    return (int)(Int16)constant.Value;
                case TypeCode.Int32:
                    return (int)constant.Value;
                default:
                    throw new NotSupportedException(string.Format("Constant {0} is of a non supported type ({1})", constant.ToString(), constant.Value.GetType().Name));
            }
        }
        internal static double GetDoubleConstant(ConstantExpression constant)
        {
            switch (Type.GetTypeCode(constant.Value.GetType()))
            {
                case TypeCode.Double:
                    return (double)constant.Value;
                default:
                    throw new NotSupportedException(string.Format("Constant {0} is of a non supported type ({1})", constant.ToString(), constant.Value.GetType().Name));
            }
        }

    }
}
