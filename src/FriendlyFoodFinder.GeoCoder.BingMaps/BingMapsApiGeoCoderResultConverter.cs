using System.Net.Http;
using FriendlyFoodFinder.Core;

namespace FriendlyFoodFinder.GeoCoder.BingMaps
{
    public class BingMapsApiGeoCoderResultConverter
    {
        public GeoLocation Convert(HttpResponseMessage apiResult)
        {
            return new GeoLocation(0,0);
        }
    }
}