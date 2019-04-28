using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FriendlyFoodFinder.Core.Specification;

namespace FriendlyFoodFinder.Core
{
    public class FoodTruckQuery : IQueryForFoodTrucks
    {
        public Task<IEnumerable<FoodTruck>> Find(IEnumerable<FoodTruck> foodTrucks, FoodTruckQueryParameters queryParameters)
        {
            ValidateFoodTrucks(foodTrucks);
            ValidateQueryParameters(queryParameters);

            //TODO: enhance query expression/predicate to account for additional constraints defined in queryParameters
            return Task.FromResult(
                foodTrucks
                    .Where(truck => truck.IsPermitApproved == queryParameters.RestrictToPermitApproved
                        && !truck.GeoDistanceFromQueryOrigin.Equals(0))
                    .OrderBy(truck => truck.GeoDistanceFromQueryOrigin)
                    .Take(queryParameters.MaxResults)
                );

        }

        public Task<IEnumerable<FoodTruck>> Find(IEnumerable<FoodTruck> foodTrucks, Func<FoodTruck, bool> predicate)
        {
            ValidateFoodTrucks(foodTrucks);
            ValidatePredicate(predicate);

            return Task.FromResult(
                foodTrucks.Where(truck => !truck.GeoDistanceFromQueryOrigin.Equals(0)).Where(predicate)
            );
        }

        private void ValidatePredicate(Func<FoodTruck, bool> predicate)
        {
            if (!new NotNull().IsSatisfiedBy(predicate))
            {
                throw new ArgumentException("Predicate FUNC cannot be NULL.", nameof(predicate));
            }
        }

        private void ValidateQueryParameters(FoodTruckQueryParameters queryParameters)
        {
            if (!new NotNull().IsSatisfiedBy(queryParameters))
            {
                throw new ArgumentException("Parameters object cannot be NULL.", nameof(queryParameters));
            }
        }

        private void ValidateFoodTrucks(IEnumerable<FoodTruck> foodTrucks)
        {
            if (!new NotNull().IsSatisfiedBy(foodTrucks))
            {
                throw new ArgumentException("Collection cannot be NULL.", nameof(foodTrucks));
            }
        }
    }
}