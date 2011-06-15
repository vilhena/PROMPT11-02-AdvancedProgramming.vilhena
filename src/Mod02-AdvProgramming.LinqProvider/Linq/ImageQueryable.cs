using Mod02_AdvProgramming.LinqProvider.ImagesMetadata;

namespace Mod02_AdvProgramming.LinqProvider.Linq
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;

    internal class ImageQueryable : IQueryable<ImageInformation>
    {
        ImageQueryProvider provider;
        Expression expression;

        public ImageQueryable(ImageQueryProvider provider)
        {
            if (provider == null)
            {
                throw new ArgumentNullException("provider");
            }
            this.provider = provider;
            this.expression = Expression.Constant(this);
        }

        public ImageQueryable(ImageQueryProvider provider, Expression expression)
        {
            if (provider == null)
            {
                throw new ArgumentNullException("provider");
            }
            if (expression == null)
            {
                throw new ArgumentNullException("expression");
            }
            if (!typeof(IQueryable<ImageInformation>).IsAssignableFrom(expression.Type))
            {
                throw new ArgumentOutOfRangeException("expression");
            }
            this.provider = provider;
            this.expression = expression;
        }

        #region IQueryable implementation
        Expression IQueryable.Expression
        {
            get { return this.expression; }
        }

        Type IQueryable.ElementType
        {
            get { return typeof(ImageInformation); }
        }

        IQueryProvider IQueryable.Provider
        {
            get { return this.provider; }
        }
        #endregion IQueryable implementation

        #region IEnumerable<T> implementation
        public IEnumerator<ImageInformation> GetEnumerator()
        {
            return ((IEnumerable<ImageInformation>)this.provider.Execute(this.expression)).GetEnumerator();
        }
        #endregion IEnumerable<T> implementation

        #region IEnumerable implementation
        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this.provider.Execute(this.expression)).GetEnumerator();
        }
        #endregion IEnumerable implementation

        public override string ToString()
        {
            return this.provider.GetQueryText(this.expression);
        }
    }
}