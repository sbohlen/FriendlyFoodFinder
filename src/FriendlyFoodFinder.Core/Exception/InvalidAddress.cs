namespace FriendlyFoodFinder.Core.Exception
{
    public class InvalidAddress : System.Exception
    {
        public InvalidAddress(string address)
        {
            //TODO: store the address and use to craft e.g., messages from the exception
            //NIE removed here so that testing for this exception won't incorrectly throw NIE instead
        }
    }
}