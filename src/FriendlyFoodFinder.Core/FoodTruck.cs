namespace FriendlyFoodFinder.Core
{
    public class FoodTruck
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public FacilityType FoodFacilityType { get; set; }
        public string Address { get; set; }
        public bool IsPermitApproved { get; set; }
        public double Lat { get; set; }
        public double Lon { get; set; }
        public string HoursOfOperation { get; set; }
        public string FoodItems { get; set; }


        public enum FacilityType
        {
            Truck,
            PushCart
        }
    }
}