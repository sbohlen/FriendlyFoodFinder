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
            var uriString = _uriTemplate.Replace(_apiKeyUriTemplateSlug, _apiKey).Replace(_addressUriTemplateSlug, address);
            var uri = new Uri(uriString);

            var apiResult = await _client.GetAsync(uri);
            ValidateApiResult(apiResult);
            return ConvertApiResultToGeoLocation(apiResult);
        }

        private void ValidateApiResult(HttpResponseMessage apiResult)
        {
            if (apiResult.StatusCode != HttpStatusCode.OK)
            {
                throw new UnableToGeoCodeAddress(apiResult);
            }
        }

        private GeoLocation ConvertApiResultToGeoLocation(HttpResponseMessage apiResult)
        {
            return _converter.Convert(apiResult);
        }
    }
}