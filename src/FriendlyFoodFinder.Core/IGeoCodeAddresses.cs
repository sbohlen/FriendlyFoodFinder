using System.Threading.Tasks;

namespace FriendlyFoodFinder.Core
{
    public interface IGeoCodeAddresses
    {
        Task<GeoLocation> GeoCodeAddress(string address);
    }
}