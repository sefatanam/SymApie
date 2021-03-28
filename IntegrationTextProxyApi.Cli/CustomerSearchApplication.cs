using System.Threading.Tasks;
using CommandLine;
using IntegrationTextProxyApi.Cli.Output;

namespace IntegrationTextProxyApi.Cli
{
    public class CustomerSearchApplication
    {
        private readonly IConsoleWriter _consoleWriter;

        public CustomerSearchApplication(IConsoleWriter consoleWriter)
        {
            _consoleWriter = consoleWriter;
        }

        public async Task RunAsync(string[] args)
        {
            await Parser.Default
                .ParseArguments<CustomerSearchApplicationOption>(args)
                .WithParsedAsync(option =>
                {
                    // _consoleWriter.WriteLine($"The Customer Id was {option.Id}");
                    return Task.CompletedTask;
                });
        }
    }
}