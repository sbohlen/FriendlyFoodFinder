using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FriendlyFoodFinder.Core
{
    public interface IReadFoodTruckData
    {
        Task<IEnumerable<FoodTruck>> ReadData(string csvFilePath);
    }
}