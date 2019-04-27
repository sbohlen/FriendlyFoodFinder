using System;
using System.Net.Http;

namespace FriendlyFoodFinder.GeoCoder.BingMaps
{
    public class UnableToGeoCodeAddress : Exception
    {
        public UnableToGeoCodeAddress(HttpResponseMessage apiResult)
        {
            throw new NotImplementedException();
        }

        public UnableToGeoCodeAddress(Exception innerException) : base(innerException.ToString())
        {

        }
    }
}