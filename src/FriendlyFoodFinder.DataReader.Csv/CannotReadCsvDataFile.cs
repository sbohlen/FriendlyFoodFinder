using System;

namespace FriendlyFoodFinder.DataReader.Csv
{
    public class CannotReadCsvDataFile : Exception
    {
        public CannotReadCsvDataFile(string csvDataFilePath)
        {
            //TODO: store the csvDataFilePath and use to craft e.g., messages from the exception
            //NIE removed here so that testing for this exception won't incorrectly throw NIE instead
            //throw new NotImplementedException();
        }
    }
}