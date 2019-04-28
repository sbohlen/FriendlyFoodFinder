using System.Threading.Tasks;

namespace FriendlyFoodFinder.Core
{
    public interface ICalculateGeoDistance
    {
        Task<double> CalculateGeoDistanceBetween(GeoLocation start, GeoLocation end);
    }
}