using Proteus.Domain.Foundation;

namespace FriendlyFoodFinder.Core
{
    public class FoodTruckQueryParameters : ValueObjectBase<FoodTruckQueryParameters>
    {
        public bool RestrictToPermitApproved { get; set; } = true;
        public string FoodItemsContains { get; set; }
        public string VendorNameContains { get; set; }
        public int MaxResults { get; set; } = 5;
        public double MaxDistance { get; set; } = 0;
        public bool CompareCurrentTimeWithinOperatingHours { get; set; }

    }
}