using System;
using System.Threading.Tasks;
using FriendlyFoodFinder.Core.Exception;
using FriendlyFoodFinder.Core.Specification;

namespace FriendlyFoodFinder.Core
{
    public class GeoLocationCoder
    {
        private readonly IGeoCodeAddresses _geoCoderService;

        public GeoLocationCoder(IGeoCodeAddresses geoCoderService)
        {
            ValidateGeoCoderService(geoCoderService);
            _geoCoderService = geoCoderService;
        }

        private void ValidateGeoCoderService(IGeoCodeAddresses geoCoderService)
        {
            if (!new NotNull().IsSatisfiedBy(geoCoderService))
            {
                throw new  ArgumentException("Cannot be NULL", nameof(geoCoderService));
            }
        }

        public async Task<GeoLocation> GeoCode(string address)
        {
            ValidateAddress(address);

            return await _geoCoderService.GeoCodeAddress(address);
        }

        private void ValidateAddress(string address)
        {
            if (!new ValidAddressString().IsSatisfiedBy(address))
            {
                throw new InvalidAddress(address);
            }
        }
    }
}