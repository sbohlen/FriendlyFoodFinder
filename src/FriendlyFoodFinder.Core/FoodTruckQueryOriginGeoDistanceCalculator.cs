﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FriendlyFoodFinder.Core.Specification;

namespace FriendlyFoodFinder.Core
{
    public class FoodTruckQueryOriginGeoDistanceCalculator
    {
        private readonly ICalculateGeoDistance _calculator;

        public FoodTruckQueryOriginGeoDistanceCalculator(ICalculateGeoDistance calculator)
        {
            _calculator = calculator;
        }

        public async Task AddGeoDistanceFromQueryOrigin(GeoLocation queryOrigin, IEnumerable<FoodTruck> foodTrucks)
        {
            ValidateQueryOrigin(queryOrigin);
            ValidateFoodTrucks(foodTrucks);

            foreach (var foodTruck in foodTrucks)
            {
                var truckLocation = new GeoLocation(foodTruck.Lat, foodTruck.Lon);
                foodTruck.GeoDistanceFromQueryOrigin = await _calculator.CalculateGeoDistanceBetween(queryOrigin, truckLocation);
            }
        }

        private void ValidateFoodTrucks(IEnumerable<FoodTruck> foodTrucks)
        {
            if (!new NotNull().IsSatisfiedBy(foodTrucks))
            {
                throw new ArgumentException("Collection cannot be NULL.", nameof(foodTrucks));
            }
        }

        private void ValidateQueryOrigin(GeoLocation queryOrigin)
        {
            if (!new NotNull().IsSatisfiedBy(queryOrigin))
            {
                throw new ArgumentException("Argument cannot be NULL.", nameof(queryOrigin));
            }
        }
    }
}