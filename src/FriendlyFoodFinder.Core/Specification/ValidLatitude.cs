using System;
using System.Linq.Expressions;
using Proteus.Domain.Foundation.Specifications;

namespace FriendlyFoodFinder.Core.Specification
{
    public class ValidLatitude : Specification<double>
    {

        private const double MaxLatitude = 90;
        private const double MinLatitude = -90;

        public override Expression<Func<double, bool>> Predicate
        {
            get { return lat => lat <= MaxLatitude && lat >= MinLatitude; }

        }
    }
}