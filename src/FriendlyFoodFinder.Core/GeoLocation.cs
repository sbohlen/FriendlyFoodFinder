using FriendlyFoodFinder.Core.Exception;
using FriendlyFoodFinder.Core.Specification;
using Proteus.Domain.Foundation;

namespace FriendlyFoodFinder.Core
{
    public class GeoLocation : ValueObjectBase<GeoLocation>
    {
        public GeoLocation(double latitude, double longitude)
        {
            ValidateLatLonValues(latitude, longitude);

            Lat = latitude;
            Lon = longitude;
        }

        public double Lat { get; }
        public double Lon { get; }

        private void ValidateLatLonValues(double latitude, double longitude)
        {
            if (!new ValidLatitude().IsSatisfiedBy(latitude))
            {
                throw new InvalidLatitudeValue(latitude);
            }

            if (!new ValidLongitude().IsSatisfiedBy(longitude))
            {
                throw new InvalidLongitudeValue(latitude);
            }
        }

        public override string ToString()
        {
            return $"Lat: {Lat}, Lon {Lon}";
        }
    }
}