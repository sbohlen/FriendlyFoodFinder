
using FriendlyFoodFinder.Core.Exception;
using NUnit.Framework;

namespace FriendlyFoodFinder.Core.Test
{
    [TestFixture]
    public class WhenCreatingGeoLocation
    {
        private const double VALID_LATITUDE = 20;
        private const double VALID_LONGITUDE = 10;
        private const double INVALID_LATITUDE = 100;
        private const double INVALID_LONGITUDE = 200;

        [Test]
        public void CanAcceptValidValues()
        {
            Assert.DoesNotThrow(() => new GeoLocation(VALID_LATITUDE, VALID_LONGITUDE));
        }


        [Test]
        public void CanRejectInvalidLatitudeValues()
        {
            Assert.Throws<InvalidLatitudeValue>(() => new GeoLocation(INVALID_LATITUDE, VALID_LONGITUDE));
        }

        [Test]
        public void CanRejectInvalidLongitudeValues()
        {
            Assert.Throws<InvalidLongitudeValue>(() => new GeoLocation(VALID_LATITUDE, INVALID_LONGITUDE));
        }
    }
}