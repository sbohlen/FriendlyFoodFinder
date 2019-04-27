using System;
using System.Linq.Expressions;
using Proteus.Domain.Foundation.Specifications;

namespace FriendlyFoodFinder.Core.Specification
{
    public class ValidLongitude : Specification<double>
    {
        private const double MaxLongitude = 180;
        private const double MinLongitude = -180;

        public override Expression<Func<double, bool>> Predicate
        {
            get { return lon => lon <= MaxLongitude && lon >= MinLongitude; }

        }
    }
}