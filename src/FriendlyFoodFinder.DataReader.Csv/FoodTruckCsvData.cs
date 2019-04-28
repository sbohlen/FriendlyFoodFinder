//auto-generated from https://toolslick.com/generation/code/class-from-csv

using System;
using CsvHelper.Configuration;

namespace FriendlyFoodFinder.DataReader.Csv
{
    public class FoodTruckCsvData
    {
        public int Locationid { get; set; }
        public string Applicant { get; set; }
        public string FacilityType { get; set; }
        public int Cnn { get; set; }
        public string LocationDescription { get; set; }
        public string Address { get; set; }
        public string Blocklot { get; set; }
        public string Block { get; set; }
        public string Lot { get; set; }
        public string Permit { get; set; }
        public string Status { get; set; }
        public string FoodItems { get; set; }
        public string X { get; set; }
        public string Y { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Schedule { get; set; }
        public string Dayshours { get; set; }
        public string NOISent { get; set; }
        public string Approved { get; set; }
        public DateTime Received { get; set; }
        public int PriorPermit { get; set; }
        public string ExpirationDate { get; set; }
        public string Location { get; set; }
        public int? FirePreventionDistricts { get; set; }
        public int? PoliceDistricts { get; set; }
        public int? SupervisorDistricts { get; set; }
        public int? ZipCodes { get; set; }
        public int? Neighborhoods { get; set; }
    }

    public class FoodTruckCsvDataClassMap : ClassMap<FoodTruckCsvData>
    {
        public FoodTruckCsvDataClassMap()
        {
            Map(m => m.Locationid).Name("locationid");
            Map(m => m.Applicant).Name("Applicant");
            Map(m => m.FacilityType).Name("FacilityType");
            Map(m => m.Cnn).Name("cnn");
            Map(m => m.LocationDescription).Name("LocationDescription");
            Map(m => m.Address).Name("Address");
            Map(m => m.Blocklot).Name("blocklot");
            Map(m => m.Block).Name("block");
            Map(m => m.Lot).Name("lot");
            Map(m => m.Permit).Name("permit");
            Map(m => m.Status).Name("Status");
            Map(m => m.FoodItems).Name("FoodItems");
            Map(m => m.X).Name("X");
            Map(m => m.Y).Name("Y");
            Map(m => m.Latitude).Name("Latitude");
            Map(m => m.Longitude).Name("Longitude");
            Map(m => m.Schedule).Name("Schedule");
            Map(m => m.Dayshours).Name("dayshours");
            Map(m => m.NOISent).Name("NOISent");
            Map(m => m.Approved).Name("Approved");
            Map(m => m.Received).Name("Received");
            Map(m => m.PriorPermit).Name("PriorPermit");
            Map(m => m.ExpirationDate).Name("ExpirationDate");
            Map(m => m.Location).Name("Location");
            Map(m => m.FirePreventionDistricts).Name("Fire Prevention Districts");
            Map(m => m.PoliceDistricts).Name("Police Districts");
            Map(m => m.SupervisorDistricts).Name("Supervisor Districts");
            Map(m => m.ZipCodes).Name("Zip Codes");
            Map(m => m.Neighborhoods).Name("Neighborhoods");
        }
    }

}