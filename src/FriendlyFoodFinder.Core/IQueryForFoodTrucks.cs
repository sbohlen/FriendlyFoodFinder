using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FriendlyFoodFinder.Core
{
    public interface IQueryForFoodTrucks
    {
        Task<IEnumerable<FoodTruck>> Find(IEnumerable<FoodTruck> foodTrucks, FoodTruckQueryParameters queryParameters);
        Task<IEnumerable<FoodTruck>> Find(IEnumerable<FoodTruck> foodTrucks, Func<FoodTruck, bool> predicate);

    }
}