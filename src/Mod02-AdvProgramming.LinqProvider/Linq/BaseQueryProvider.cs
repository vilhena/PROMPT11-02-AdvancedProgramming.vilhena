using System;
using System.Linq;
using System.Linq.Expressions;

namespace Mod02_AdvProgramming.LinqProvider.Linq
{
    public abstract class BaseQueryProvider : IQueryProvider
    {
        public IQueryable<T> CreateQuery<T>(Expression expression)
        {
            if (expression == null)
            {
                throw new ArgumentNullException("expression");
            }
            if (!typeof(IQueryable<T>).IsAssignableFrom(expression.Type))
            {
                throw new ArgumentException("Argument expression is not valid");
            }
            return (IQueryable<T>)this.CreateQuery(expression);
        }
        public TResult Execute<TResult>(Expression expression)
        {
            if (expression == null)
            {
                throw new ArgumentNullException("expression");
            }
            if (!typeof(IQueryable<TResult>).IsAssignableFrom(expression.Type))
            {
                throw new ArgumentException("Argument expression is not valid");
            }
            return (TResult)this.Execute(expression);
        }
        public abstract IQueryable CreateQuery(Expression expression);
        public abstract object Execute(Expression expression);
    }
}