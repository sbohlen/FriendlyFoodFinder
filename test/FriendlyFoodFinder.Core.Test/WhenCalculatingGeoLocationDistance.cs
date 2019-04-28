using System;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace FriendlyFoodFinder.Core.Test
{
    [TestFixture]
    public class WhenCalculatingGeoLocationDistance
    {
        [TestCase(0,0,20,20,28.2,28.3)]
        [TestCase(-10,-10,10,10,28.2,28.3)]
        public async Task CanCalculateDistanceBetweenValidGeoLocations(double startLat, double startLon, double endLat, double endLon, double minAssertRange, double maxAssertRange)
        {
            var calculator = new PlanarGeoLocationDistanceCalculator();

            var start = new GeoLocation(startLat, startLon);
            var end = new GeoLocation(endLat, endLon);

            //assert for approx. equality to permit double/float rounding errors irrelevant for our use-case
            Assert.That(await calculator.CalculateGeoDistanceBetween(start, end), Is.InRange(minAssertRange, maxAssertRange));
        }

        [Test]
        public void CanProtectAgainstInvalidGeoLocations()
        {
            var calculator = new PlanarGeoLocationDistanceCalculator();
            var geoLocation = new GeoLocation(0, 0);

            Assert.ThrowsAsync<ArgumentException>(() => calculator.CalculateGeoDistanceBetween(geoLocation, null));
            Assert.ThrowsAsync<ArgumentException>(() => calculator.CalculateGeoDistanceBetween(null, geoLocation));

        }
    }
}