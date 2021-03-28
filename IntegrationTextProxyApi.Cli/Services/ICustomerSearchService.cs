using System.Threading.Tasks;
using IntegrationTextProxyApi.Cli.Models;
using OneOf;

namespace IntegrationTextProxyApi.Cli.Services
{
    public interface ICustomerSearchService
    {
        public Task<OneOf<CustomerResult,CustomerSearchError>> SearchByIdAsync(CustomerSearchRequest request);
    }
}