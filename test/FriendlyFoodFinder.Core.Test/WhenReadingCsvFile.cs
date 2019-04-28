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
            var reader = new FoodTruckCsvDataReader();
            var data = await reader.ReadData(@"foodTruckData.csv");

            Assert.That(data, Is.Not.Null);
            Assert.That(data.Count(), Is.GreaterThan(0));
        }

        [Test]
        public void CanPreventAccessToInvalidFile()
        {
            var fileDoesntExist = @"file-doesnt-exist.csv";

            var reader = new FoodTruckCsvDataReader();

            Assume.That(File.Exists(fileDoesntExist), Is.False);
            Assert.ThrowsAsync<CannotReadCsvDataFile>(() => reader.ReadData(fileDoesntExist));
        }
    }
}