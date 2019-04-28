using System.Collections.Generic;
using System.Threading.Tasks;
using NUnit.Framework;

namespace FriendlyFoodFinder.Core.Test
{
    [TestFixture]
    public class WhenCalculatingDistanceFromQueryLocationToFoodTrucks
    {
        private List<FoodTruck> _foodTrucks;
        private GeoLocation _queryLocation;


        [SetUp]
        public void SetUp()
        {
            _foodTrucks = new List<FoodTruck>
            {
                new FoodTruck { Lat = -10, Lon = -10},
                new FoodTruck{ Lat = 10, Lon = 10},
                new FoodTruck{ Lat=20, Lon = 20},
            };

            _queryLocation = new GeoLocation(0, 0);
        }


        [Test]
        public async Task CanAddDistanceToEachFoodTruck()
        {
            foreach (var foodTruck in _foodTrucks)
            {
                Assume.That(foodTruck.Lat, Is.Not.EqualTo(0),"Test assumes that no food truck will be located at the query location.");
                Assume.That(foodTruck.Lon, Is.Not.EqualTo(0),"Test assumes that no food truck will be located at the query location.");
            }

            var calculator = new FoodTruckQueryOriginGeoDistanceCalculator(new PlanarGeoDistanceCalculator());
            await calculator.AddGeoDistanceFromQueryOrigin(_queryLocation, _foodTrucks);

            foreach (var foodTruck in _foodTrucks)
            {
                Assert.That(foodTruck.GeoDistanceFromQueryOrigin, Is.GreaterThan(0));
            }
        }
    }
}