using System;
using System.Net.Http;

namespace FriendlyFoodFinder.GeoCoder.BingMaps
{
    public class UnableToGeoCodeAddress : Exception
    {
        public UnableToGeoCodeAddress(HttpResponseMessage apiResult)
        {
            //TODO: store the apiResult and use to craft e.g., messages from the exception
            //NIE removed here so that testing for this exception won't incorrectly throw NIE instead
            //throw new NotImplementedException();  
        }

        public UnableToGeoCodeAddress(Exception innerException) : base(innerException.ToString())
        {

        }
    }
}