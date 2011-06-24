using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using ChelasInjection.ActivationPlugins;

namespace ChelasInjection.Cache
{
    internal class ExpressionRecorder
    {
        private Queue<Expression> _executionQueue = new Queue<Expression>();
        private Dictionary<object, Expression> _objectVariables = new Dictionary<object, Expression>();
        private int _varNameCount;

        private string NewVariable
        {
            get { return "local" + ++_varNameCount; }
        }

        private string CurrentVariable
        {
            get { return "local" + _varNameCount; }
        }


        public void Start()
        {
            _varNameCount = 0;
            _executionQueue = new Queue<Expression>();
            _objectVariables = new Dictionary<object, Expression>();
        }

        public void Stop()
        {
        }

        public LambdaExpression Result()
        {
            if (_executionQueue.Count == 0)
                return null;

            var listLocal = new List<ParameterExpression>();
            var listAssigns = new List<Expression>();

            while (_executionQueue.Count > 0)
            {
                Expression ex = _executionQueue.Dequeue();

                if (ex.NodeType == ExpressionType.Assign)
                {
                    var assign = ex as BinaryExpression;
                    listLocal.Add((ParameterExpression) assign.Left);
                }
                listAssigns.Add(ex);
            }
            
            listAssigns.Add(listLocal.Last());

            BlockExpression block = Expression.Block(
                listLocal.ToArray(),
                listAssigns.ToArray()
                );

            return Expression.Lambda<Func<object>>(
                block
                );
        }


        public object ActivatorCreateInstance(TypeKey type, Type targetType, object[] args, IActivationPlugin activationPlugin)
        {
            object newObj = Activator.CreateInstance(targetType, args);
            activationPlugin.NewInstance(type, newObj);

            var activationType = activationPlugin.GetConstructorExpression();

            ConstructorInfo ctor = targetType.GetConstructor(args.Select(o => o.GetType()).ToArray());

            ParameterExpression newVar = Expression.Variable(targetType, NewVariable);

            Expression ex;

            if (activationType == ExpressionType.Constant)
                ex = Expression.Constant(newObj);
            else
                ex = Expression.New(ctor,
                                    args.Select(FindVariableName));


            _objectVariables.Add(newObj, newVar);
            _executionQueue.Enqueue(Expression.Assign(newVar, ex));

            return newObj;
        }

        private Expression FindVariableName(object o)
        {
            if (_objectVariables.ContainsKey(o))
                return _objectVariables[o];
            else
            {
                return Expression.Constant(o);
            }
        }

        public object PropertyGetValue(PropertyInfo pinfo, object obj)
        {
            object pValue = pinfo.GetValue(obj, new object[] {});

            ParameterExpression newVar = Expression.Variable(pinfo.PropertyType, NewVariable);
            MemberExpression ex =
                Expression.Property(_objectVariables[obj], pinfo);


            _objectVariables.Add(pValue, newVar);
            _executionQueue.Enqueue(Expression.Assign(newVar, ex));

            return pValue;
        }

        internal object GetConstructorValues(Func<object> func)
        {
            object retType = func();

            if (!_objectVariables.ContainsKey(retType))
            {
                ParameterExpression newVar = Expression.Variable(typeof (object), NewVariable);
                MethodCallExpression ex =
                    Expression.Call(func.Method);

                _objectVariables.Add(retType, newVar);
                _executionQueue.Enqueue(Expression.Assign(newVar, ex));
            }
            return retType;
        }

        internal void InitializeObjectWith(Action<object> initialization, object newObj)
        {
            //initialize object
            initialization(newObj);

            InvocationExpression ex = Expression.Invoke(Expression.Constant(initialization),
                                                        _objectVariables[newObj]);

            _executionQueue.Enqueue(ex);
        }

        internal void CustomResolve(ResolverHandler resolverHandler, object obj, Binder binder, Type targetType, IActivationPlugin activationPlugin)
        {
            //initialize object
            var ctorExpression = activationPlugin.GetConstructorExpression();

            ParameterExpression newVar = Expression.Variable(obj.GetType(), NewVariable);
            BinaryExpression ex;

            if (ctorExpression == ExpressionType.Constant)
            {
                ex = Expression.Assign(newVar, Expression.Constant(obj));
            }
            else
            {
                InvocationExpression del = Expression.Invoke(Expression.Constant(resolverHandler)
                                                             , new Expression[]
                                                                   {
                                                                       Expression.Constant(binder),
                                                                       Expression.Constant(targetType)
                                                                   });

                ex = Expression.Assign(newVar, Expression.Convert(del, obj.GetType()));
            }

            _objectVariables.Add(obj, newVar);

            _executionQueue.Enqueue(ex);
        }
    }
}