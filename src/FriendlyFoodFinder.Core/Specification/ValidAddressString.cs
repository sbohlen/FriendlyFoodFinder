using System;
using System.Linq.Expressions;
using Proteus.Domain.Foundation.Specifications;

namespace FriendlyFoodFinder.Core.Specification
{
    public class ValidAddressString : Specification<string>
    {
        public override Expression<Func<string, bool>> Predicate
        {
            get { return candidate => !string.IsNullOrWhiteSpace(candidate); }
        }
    }
}