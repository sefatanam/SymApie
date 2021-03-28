using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using IntegrationTextProxyApi.Cli.Api;
using IntegrationTextProxyApi.Cli.Models;
using OneOf;

namespace IntegrationTextProxyApi.Cli.Services
{
    public class CustomerSearchService : ICustomerSearchService
    {
        private readonly ICustomerApi _customerApi;
        private readonly IValidator<CustomerSearchRequest> _validator;

        public CustomerSearchService(ICustomerApi customerApi, IValidator<CustomerSearchRequest> validator)
        {
            _customerApi = customerApi;
            _validator = validator;
        }

        public async Task<OneOf<CustomerResult,CustomerSearchError>> SearchByIdAsync(CustomerSearchRequest request)
        {

            // STEPS ARE =>
            // 1. VALIDATE REQUEST OBJECT
            // 2. CALL API & MAP RESPONSE

            var validatorResult = _validator.Validate(request);
            if (!validatorResult.IsValid)
            {
                var errorMessages = validatorResult.Errors.Select(m => m.ErrorMessage).ToList();
                return new CustomerSearchError(errorMessages);
            }
            var response = await _customerApi.SearchByIdAsync(request.Id);
            return new CustomerResult
            {
                AddressResponse = response.AddressResponse,
                CompanyResponse = response.CompanyResponse
            };

        }
    }
}