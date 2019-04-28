using System.IO;
using System.Linq;
using System.Threading.Tasks;
using FriendlyFoodFinder.DataReader.Csv;
using NUnit.Framework;
using NUnit.Framework.Internal;
using Proteus.Utility.UnitTest;

namespace FriendlyFoodFinder.Core.Test
{
    [TestFixture]
    public class WhenReadingCsvFile
    {
        [Test]
        [Category(UnitTestType.Integration)]
        public async Task CanReadDataFromValidFile()
        {
            var reader = new FoodTruckCsvDataReader(@"foodTruckData.csv");
            var data = await reader.ReadData();

            Assert.That(data, Is.Not.Null);
            Assert.That(data.Count(), Is.GreaterThan(0));
        }

        [Test]
        public void CanPreventAccessToInvalidFile()
        {
            var fileDoesntExist = @"file-doesnt-exist.csv";
            Assume.That(File.Exists(fileDoesntExist), Is.False, $"Test assumes that the file {fileDoesntExist} doesn't exist.");

            var reader = new FoodTruckCsvDataReader(fileDoesntExist);

            Assert.ThrowsAsync<CannotReadCsvDataFile>(() => reader.ReadData());
        }
    }
}