using System;
using System.Threading.Tasks;
using FriendlyFoodFinder.Core.Specification;

namespace FriendlyFoodFinder.Core
{
    public class PlanarGeoDistanceCalculator : ICalculateGeoDistance
    {
        public Task<double> CalculateGeoDistanceBetween(GeoLocation start, GeoLocation end)
        {
            ValidateGeoLocation(start, nameof(start));
            ValidateGeoLocation(end, nameof(end));

            var latitudinalDistance = start.Lat - end.Lat;
            var longitudinalDistance = start.Lon - end.Lon;

            //since assuming planar distance is sufficient for our needs, Pythagoras (a^2 + b^2 = c^2) is sufficient for now 
            var distance = Math.Abs(Math.Sqrt(Math.Pow(latitudinalDistance, 2) + Math.Pow(longitudinalDistance, 2)));

            return Task.FromResult(distance);
        }

        private void ValidateGeoLocation(GeoLocation location, string argName)
        {
            if (!new NotNull().IsSatisfiedBy(location))
            {
                throw new ArgumentException("Argument cannot be NULL", argName);
            }
        }
    }
}