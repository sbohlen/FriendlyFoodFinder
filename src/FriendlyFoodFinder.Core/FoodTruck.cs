using Proteus.Domain.Foundation;

namespace FriendlyFoodFinder.Core
{
    public class FoodTruck : ValueObjectBase<FoodTruck>
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
        public double GeoDistanceFromQueryOrigin { get; set; }


        public enum FacilityType
        {
            Truck,
            PushCart
        }

        public override string ToString()
        {
            return $"Name: {Name} | Address: {Address} | Distance: {GeoDistanceFromQueryOrigin} | Food: {FoodItems} | Hours: {HoursOfOperation}";
        }
    }
}