using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace core.Specifications
{
    public class BaseSpecification<T> : ISpecification<T>
    {
        public BaseSpecification()
        {
        }

        public BaseSpecification(Expression<Func<T, bool>> criteria)
        {
            Criteria = criteria;
        
        }

        public Expression<Func<T, bool>> Criteria {get;}
        public List<Expression<Func<T, object>>> Includes {get;}
        = new List<Expression<Func<T , Object>>>();

        protected void AddInclude(Expression<Func<T , Object>> includeexpression)
        {
            Includes.Add(includeexpression);
        }
    }
}