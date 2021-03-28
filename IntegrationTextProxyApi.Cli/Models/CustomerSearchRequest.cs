namespace IntegrationTextProxyApi.Cli.Models
{
    public class CustomerSearchRequest
    {
        public CustomerSearchRequest(int id)
        {
            Id = id;
        }

        public int Id { get; }
    }
}