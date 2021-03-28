using FluentValidation;
using IntegrationTextProxyApi.Cli.Models;

namespace IntegrationTextProxyApi.Cli.Validators
{
    public class CustomerSearchRequestValidator : AbstractValidator<CustomerSearchRequest>
    {
        public CustomerSearchRequestValidator()
        {
            RuleFor(rf=>rf.Id).NotNull().GreaterThan(0)
                .WithMessage("Please provide number greater than zero.");
        }
    }
}