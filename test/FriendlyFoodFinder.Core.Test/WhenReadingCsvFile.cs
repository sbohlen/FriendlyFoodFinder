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
            var reader = new FoodTruckCsvDataReader();

            Assert.ThrowsAsync<CannotReadCsvDataFile>(() => reader.ReadData(@"file-doesnt-exist.csv"));
        }
    }
}