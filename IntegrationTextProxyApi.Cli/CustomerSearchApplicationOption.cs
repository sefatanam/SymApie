using CommandLine;

namespace IntegrationTextProxyApi.Cli
{
    public record CustomerSearchApplicationOption
    {
        [Option('d',"id",Required = true,HelpText = "Provide Customer Id to perform the search on.")]
        public int Id { get; init; }
    }
}