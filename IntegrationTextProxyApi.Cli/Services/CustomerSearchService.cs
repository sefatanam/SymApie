using System.Threading.Tasks;
using IntegrationTextProxyApi.Cli.Api;
using IntegrationTextProxyApi.Cli.Models;

namespace IntegrationTextProxyApi.Cli.Services
{
    public class CustomerSearchService : ICustomerSearchService
    {
        private readonly ICustomerApi _customerApi;

        public CustomerSearchService(ICustomerApi customerApi)
        {
            _customerApi = customerApi;
        }

        public async Task<CustomerResult> SearchByIdAsync(CustomerSearchRequest request)
        {
            // VALIDATE REQUEST OBJECT
            var response = await _customerApi.SearchByIdAsync(request.Id);
            return new CustomerResult
            {
                AddressResponse = response.AddressResponse,
                CompanyResponse = response.CompanyResponse
            };

            // CALL API & MAP RESPONSE
        }
    }
}