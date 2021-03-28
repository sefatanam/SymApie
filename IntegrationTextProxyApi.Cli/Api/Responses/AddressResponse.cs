using System.Text.Json.Serialization;

namespace IntegrationTextProxyApi.Cli.Api.Responses
{
    public record AddressResponse
    {
        [JsonPropertyName("street")]
        public string Street { get; set; }
    
        [JsonPropertyName("suite")]
        public string Suite { get; set; }
    
        [JsonPropertyName("city")]
        public string City { get; set; }
    
        [JsonPropertyName("zipcode")]
        public string Zipcode { get; set; }
    }
}