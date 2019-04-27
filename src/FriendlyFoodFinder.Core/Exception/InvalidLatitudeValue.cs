using System;

namespace FriendlyFoodFinder.Core.Exception
{
    public class InvalidLatitudeValue : System.Exception
    {
        public InvalidLatitudeValue(double latitude)
        {
            //TODO: store the latitude and use to craft e.g., messages from the exception
            //NIE removed here so that testing for this exception won't incorrectly throw NIE instead
            //throw new NotImplementedException();  
        }
    }
}