using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using FriendlyFoodFinder.Core;
using Proteus.Utility.Configuration;

namespace FriendlyFoodFinder.GeoCoder.BingMaps
{
    public class BingMapsGeoCoderService : IGeoCodeAddresses
    {
        private readonly BingMapsApiGeoCoderResultConverter _converter;
        private HttpClient _client;
        private string _uriTemplate;
        private string _addressUriTemplateSlug;
        private string _apiKeyUriTemplateSlug;
        private string _apiKey;

        public BingMapsGeoCoderService(BingMapsApiGeoCoderResultConverter converter)
        {
            _converter = converter;
            _addressUriTemplateSlug = ExtensibleSourceConfigurationManager.AppSettings("bingMapsAddressUriTemplateSlug");
            _apiKeyUriTemplateSlug = ExtensibleSourceConfigurationManager.AppSettings("bingMapsApiKeyUriTemplateSlug");
            _apiKey = ExtensibleSourceConfigurationManager.AppSettings("bingMapsApiKey");
            _client = new HttpClient();
            _uriTemplate = ExtensibleSourceConfigurationManager.AppSettings("bingMapsGeoLocationUriTemplate"); 
        }

        public async Task<GeoLocation> GeoCodeAddress(string address)
        {
            try
            {
                var uriString = _uriTemplate.Replace(_apiKeyUriTemplateSlug, _apiKey).Replace(_addressUriTemplateSlug, address);
                var uri = new Uri(uriString);

                var apiResult = await _client.GetAsync(uri);
                ValidateApiResult(apiResult);
                return await ConvertApiResultToGeoLocation(apiResult);
            }
            catch (Exception ex)
            {
                throw new UnableToGeoCodeAddress(ex);
            }
        }

        private void ValidateApiResult(HttpResponseMessage apiResult)
        {
            //TODO: explore the _other_ ways that the BING MAPS API can return a 200 but still potentially not contain a valid geocoded location
            // (e.g., address-not-exist)
            if (apiResult.StatusCode != HttpStatusCode.OK)
            {
                throw new UnableToGeoCodeAddress(apiResult);
            }
        }

        private async Task<GeoLocation> ConvertApiResultToGeoLocation(HttpResponseMessage apiResult)
        {
            return await _converter.Convert(apiResult);
        }
    }
}