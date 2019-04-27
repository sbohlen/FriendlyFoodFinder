using NUnit.Framework;
using NUnit.Framework.Constraints;

namespace FriendlyFoodFinder.Core.Test
{
    [TestFixture]
    public class WhenGeocodingAddress
    {
        private const string TEST_ADDRESS_STRING = "11 Times Square, New York, New York";
        private GeoLocation expectedGeoLocation;

        [SetUp]
        public void SetUp()
        {
            expectedGeoLocation = new GeoLocation(1d,2d);
        }
 

        [Test]
        public void CanGeocodeValidAddress()
        {
            var geoCoder = new GeoLocationCoder();
            var geoLocation = geoCoder.GeoCode(TEST_ADDRESS_STRING);

            Assert.That(geoLocation, Is.EqualTo(expectedGeoLocation));
        }
    }

    public class GeoLocationCoder
    {
        public GeoLocation GeoCode(string address)
        {
            throw new System.NotImplementedException();
        }
    }

    public class GeoLocation
    {
        public GeoLocation(double longitude, double latitude)
        {
            throw new System.NotImplementedException();
        }
    }
}