using System;
using System.Linq.Expressions;
using Proteus.Domain.Foundation.Specifications;

namespace FriendlyFoodFinder.Core.Specification
{
    public class NotNull : Specification<object>
    {
        public override Expression<Func<object, bool>> Predicate
        {
            get { return candidate => null != candidate; }
        }
    }
}