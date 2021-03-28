using System.Threading.Tasks;
using IntegrationTextProxyApi.Cli.Models;

namespace IntegrationTextProxyApi.Cli.Services
{
    public interface ICustomerSearchService
    {
        public Task<CustomerResult> SearchByIdAsync(CustomerSearchRequest request);
    }
}