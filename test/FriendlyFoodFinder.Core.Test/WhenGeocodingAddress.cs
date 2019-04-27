using System.Threading.Tasks;
using FriendlyFoodFinder.Core.Exception;
using FriendlyFoodFinder.GeoCoder.BingMaps;
using NUnit.Framework;
using NUnit.Framework.Constraints;
using Proteus.Utility.Configuration;
using Proteus.Utility.UnitTest;

namespace FriendlyFoodFinder.Core.Test
{
    [TestFixture]
    public class WhenGeoCodingAddress
    {
        private const string VALID_TEST_ADDRESS_STRING = "11 Times Square, New York, New York";
        private const string INVALID_TEST_ADDRESS_STRING = "     ";
        private const double EXPECTED_LAT = 40.75676;
        private const double EXPECTED_LON = -73.98984;

        private GeoLocation _expectedGeoLocation;
        private BingMapsGeoCoderService _geoCoderService;
        private GeoLocationCoder _geoCoder;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            ExtensibleSourceConfigurationManager.AppSettingReaders.Add(LocalSettingsJsonReader.GetAppSetting);
            ExtensibleSourceConfigurationManager.AppSettingReaders.Add(EnvironmentVariableReader.GetAppSetting);
        }

        [SetUp]
        public void SetUp()
        {
            _expectedGeoLocation = new GeoLocation(EXPECTED_LAT, EXPECTED_LON);
            _geoCoderService = new BingMapsGeoCoderService(new BingMapsApiGeoCoderResultConverter());
            _geoCoder = new GeoLocationCoder(_geoCoderService);
        }

        [Test]
        [Category(UnitTestType.Integration)]
        public async Task CanGeocodeValidAddress()
        {
            var geoLocation = await _geoCoder.GeoCode(VALID_TEST_ADDRESS_STRING);
            Assert.That(geoLocation, Is.EqualTo(_expectedGeoLocation), $"Did not receive expected GeoLocation result.  Expected {_expectedGeoLocation} but received {geoLocation}.");
        }

        [Test]
        public void CanRejectInvalidAddress()
        {
            Assert.ThrowsAsync<InvalidAddress>(() => _geoCoder.GeoCode(INVALID_TEST_ADDRESS_STRING));
        }
    }
}