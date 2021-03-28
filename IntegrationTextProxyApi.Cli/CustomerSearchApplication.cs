using System.Text.Json;
using System.Threading.Tasks;
using CommandLine;
using IntegrationTextProxyApi.Cli.Models;
using IntegrationTextProxyApi.Cli.Output;
using IntegrationTextProxyApi.Cli.Services;

namespace IntegrationTextProxyApi.Cli
{
    public class CustomerSearchApplication
    {
        private readonly IConsoleWriter _consoleWriter;
        private readonly ICustomerSearchService _service;

        public CustomerSearchApplication(IConsoleWriter consoleWriter, ICustomerSearchService service)
        {
            _consoleWriter = consoleWriter;
            _service = service;
        }

        public async Task RunAsync(string[] args)
        {
            await Parser.Default
                .ParseArguments<CustomerSearchApplicationOption>(args)
                .WithParsedAsync(async option =>
                {
                    var searchRequest = new CustomerSearchRequest(option.Id);
                    var result = await _service.SearchByIdAsync(searchRequest);
                    var formattedTextResult = JsonSerializer.Serialize(result, new JsonSerializerOptions
                    {
                        WriteIndented = true
                    });
                    _consoleWriter.WriteLine(formattedTextResult);
                    // _consoleWriter.WriteLine($"The Customer Id was {option.Id}");
                    //return Task.CompletedTask;
                });
        }
    }
}