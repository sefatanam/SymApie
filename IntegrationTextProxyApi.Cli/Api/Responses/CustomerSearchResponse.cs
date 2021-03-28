using System.Text.Json.Serialization;

namespace IntegrationTextProxyApi.Cli.Api.Responses
{
    public record CustomerSearchResponse
    {
        [JsonPropertyName("address")] public AddressResponse AddressResponse { get; init; }
        [JsonPropertyName("company")] public CompanyResponse CompanyResponse { get; init; }
    }
}