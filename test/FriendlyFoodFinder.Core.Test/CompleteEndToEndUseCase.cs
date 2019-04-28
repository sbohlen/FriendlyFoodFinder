using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FriendlyFoodFinder.DataReader.Csv;
using FriendlyFoodFinder.GeoCoder.BingMaps;
using NUnit.Framework;
using NUnit.Framework.Internal;
using Proteus.Utility.Configuration;

namespace FriendlyFoodFinder.Core.Test
{
    [TestFixture]
    public class CompleteEndToEndUseCase
    {
        [Test]
        public async Task TestHarness()
        {
            //setup the config subsystem to consume the local (private) override for the bing maps APO key
            ExtensibleSourceConfigurationManager.AppSettingReaders.Add(LocalSettingsJsonReader.GetAppSetting);
            
            //define the address for the origin location for the query (conceptually the user's location, but needn't necessarily be)
            var address = "11 Times Square, New York, NY";

            //geocode the address
            var geoCoder = new GeoLocationCoder(new BingMapsGeoCoderService(new BingMapsApiGeoCoderResultConverter()));
            var queryLocation = await geoCoder.GeoCode(address);

            //get the food trucks from the source data
            var foodTrucks = await GetFoodTrucks();

            //add the distance from the origin location to each food truck
            var truckToOriginDistanceCalculator = new FoodTruckQueryOriginGeoDistanceCalculator(new PlanarGeoDistanceCalculator());
            await truckToOriginDistanceCalculator.AddGeoDistanceFromQueryOrigin(queryLocation, foodTrucks);

            //specify query parameters, defaults are sensible, but can set add'l props/params if desired
            var parameters = new FoodTruckQueryParameters();


            //perform the query
            var query = new FoodTruckQuery();
            var matches = await query.Find(foodTrucks, parameters);

            Assert.That(matches.Count(), Is.EqualTo(5));

        }


        private async Task<IEnumerable<FoodTruck>> GetFoodTrucks()
        {
            var reader = new FoodTruckCsvDataReader(@"foodTruckData.csv");
            return await reader.ReadData();
        }
    }
}