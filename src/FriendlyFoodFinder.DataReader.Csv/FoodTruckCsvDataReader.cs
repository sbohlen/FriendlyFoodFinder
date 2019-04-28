using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CsvHelper;
using FriendlyFoodFinder.Core;
using FriendlyFoodFinder.Core.Specification;

namespace FriendlyFoodFinder.DataReader.Csv
{
    public class FoodTruckCsvDataReader : IReadFoodTruckData
    {
        private const string TruckFacilityTypeValue = "TRUCK";
        private const string TruckPermitApprovedStatusValue = "APPROVED";

        public async Task<IEnumerable<FoodTruck>> ReadData(string csvDataFilePath)
        {
            ValidateDataFilePath(csvDataFilePath);
            var csvData = GetDataFromCsvFile(csvDataFilePath);
            var convertedData = ConvertNativeDataToResultFormat(csvData);

            return await Task.FromResult(convertedData);
        }

        private IEnumerable<FoodTruck> ConvertNativeDataToResultFormat(IEnumerable<FoodTruckCsvData> csvData)
        {
            var results = new List<FoodTruck>();

            foreach (var dataRow in csvData)
            {
                results.Add(BuildFoodTruckFrom(dataRow));
            }

            return results;
        }

        private FoodTruck BuildFoodTruckFrom(FoodTruckCsvData nativeData)
        {
            return new FoodTruck
            {
                Id = nativeData.Locationid,
                Name = nativeData.Applicant,
                FoodFacilityType = nativeData.FacilityType.ToUpper() == TruckFacilityTypeValue ? FoodTruck.FacilityType.Truck : FoodTruck.FacilityType.PushCart,
                IsPermitApproved = nativeData.Status.ToUpper() == TruckPermitApprovedStatusValue,
                Address = nativeData.Address,
                HoursOfOperation = nativeData.Dayshours,
                FoodItems = nativeData.FoodItems,
                Lat = nativeData.Latitude,
                Lon = nativeData.Longitude,

            };
        }

        private IEnumerable<FoodTruckCsvData> GetDataFromCsvFile(string filename)
        {
            using (var reader = new StreamReader(filename))
            {
                using (var csv = new CsvReader(reader))
                {
                    csv.Configuration.RegisterClassMap<FoodTruckCsvDataClassMap>();
                    var records = csv.GetRecords<FoodTruckCsvData>().ToList();
                    return records;
                }
            }

        }

        private void ValidateDataFilePath(string dataFilePath)
        {
            if (!new CanAccessFile().IsSatisfiedBy(dataFilePath))
            {
                throw new CannotReadCsvDataFile(dataFilePath);
            }
        }
    }
}