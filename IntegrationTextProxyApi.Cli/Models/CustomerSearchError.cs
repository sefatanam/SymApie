using System.Collections.Generic;

namespace IntegrationTextProxyApi.Cli.Models
{
    public class CustomerSearchError
    {
        public IReadOnlyList<string> ErrorMessages { get; }
        public CustomerSearchError(IReadOnlyList<string> errorMessages)
        {
            ErrorMessages = errorMessages;
        }
    }
}