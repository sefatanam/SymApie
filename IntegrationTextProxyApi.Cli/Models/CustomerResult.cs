using IntegrationTextProxyApi.Cli.Api.Responses;

namespace IntegrationTextProxyApi.Cli.Models
{
    public class CustomerResult
    {
        public AddressResponse AddressResponse { get; init; }
        public CompanyResponse CompanyResponse { get; init; }
    }
}