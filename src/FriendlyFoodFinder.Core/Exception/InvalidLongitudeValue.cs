using System;

namespace FriendlyFoodFinder.Core.Exception
{
    public class InvalidLongitudeValue : System.Exception
    {
        public InvalidLongitudeValue(double latitude)
        {
            //TODO: store the address and use to craft e.g., messages from the exception
            //NIE removed here so that testing for this exception won't incorrectly throw NIE instead
            //throw new NotImplementedException();
        }
    }
}