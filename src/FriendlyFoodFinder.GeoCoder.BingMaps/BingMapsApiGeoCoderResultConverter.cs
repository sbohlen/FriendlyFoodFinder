using System.Net.Http;
using System.Threading.Tasks;
using FriendlyFoodFinder.Core;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace FriendlyFoodFinder.GeoCoder.BingMaps
{
    public class BingMapsApiGeoCoderResultConverter
    {
        public async Task<GeoLocation> Convert(HttpResponseMessage apiResult)
        {
            var content = await apiResult.Content.ReadAsStringAsync();
            var resultData = BingMapsGeoCoderResponseData.FromJson(content);

            //TODO: get smarter about how we select the specific result set/coords. if multiple results are returned
            //(e.g., sort by confidence first)
            var coordinates = resultData.ResourceSets[0].Resources[0].GeocodePoints[0].Coordinates;

            var lat = coordinates[0];
            var lon = coordinates[1];

            return new GeoLocation(lat, lon);
        }
    }
}