using IntegrationTextProxyApi.Cli.Api.Responses;
using IntegrationTextProxyApi.Cli.Models;

namespace IntegrationTextProxyApi.Cli.Mapping
{
    public static class ContractToModelMapping
    {
        public static CustomerResult ToCustomerSearchResult(this CustomerSearchResponse response)
        {
            return new()
            {
                AddressResponse = response.AddressResponse,
                CompanyResponse = response.CompanyResponse
            };
        }
    }
}