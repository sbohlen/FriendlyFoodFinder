using System.Threading.Tasks;

namespace FriendlyFoodFinder.Core
{
    public interface ICalculateGeoLocationDistance
    {
        Task<double> CalculateGeoDistanceBetween(GeoLocation start, GeoLocation end);
    }
}