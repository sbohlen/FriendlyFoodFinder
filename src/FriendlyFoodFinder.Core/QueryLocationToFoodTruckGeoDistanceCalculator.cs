using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FriendlyFoodFinder.Core.Specification;

namespace FriendlyFoodFinder.Core
{
    public class QueryLocationToFoodTruckGeoDistanceCalculator
    {
        private readonly ICalculateGeoDistance _calculator;

        public QueryLocationToFoodTruckGeoDistanceCalculator(ICalculateGeoDistance calculator)
        {
            _calculator = calculator;
        }

        public async Task AddGeoDistanceFromQueryLocationToFoodTrucks(GeoLocation queryLocation, IEnumerable<FoodTruck> foodTrucks)
        {
            ValidateQueryLocation(queryLocation);
            ValidateFoodTrucks(foodTrucks);

            foreach (var foodTruck in foodTrucks)
            {
                var truckLocation = new GeoLocation(foodTruck.Lat, foodTruck.Lon);
                foodTruck.GeoDistanceFromQueryLocation = await _calculator.CalculateGeoDistanceBetween(queryLocation, truckLocation);
            }
        }

        private void ValidateFoodTrucks(IEnumerable<FoodTruck> foodTrucks)
        {
            if (!new NotNull().IsSatisfiedBy(foodTrucks))
            {
                throw new ArgumentException("Collection cannot be NULL.", nameof(foodTrucks));
            }
        }

        private void ValidateQueryLocation(GeoLocation queryLocation)
        {
            if (!new NotNull().IsSatisfiedBy(queryLocation))
            {
                throw new ArgumentException("Argument cannot be NULL.", nameof(queryLocation));
            }
        }
    }
}