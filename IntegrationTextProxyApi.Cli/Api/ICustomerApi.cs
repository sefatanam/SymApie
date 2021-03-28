using System.Threading.Tasks;
using IntegrationTextProxyApi.Cli.Api.Responses;
using Refit;

namespace IntegrationTextProxyApi.Cli.Api
{
    public interface ICustomerApi
    {

        [Get("/{id}")]
        Task<CustomerSearchResponse> SearchByIdAsync(int id);
    }
}