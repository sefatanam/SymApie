using System;
using System.Text.Json;
using System.Threading.Tasks;
using IntegrationTextProxyApi.Cli.Api;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Refit;

namespace IntegrationTextProxyApi.Cli
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            var services = new ServiceCollection();
            services.AddRefitClient<ICustomerApi>()
                .ConfigureHttpClient(client =>
                {
                    client.BaseAddress = new Uri(configuration["CustomerApi:BaseAddress"]);
                });

            var serviceProvider = services.BuildServiceProvider();

            var client = serviceProvider.GetRequiredService<ICustomerApi>();

            var response = await client.SearchByIdAsync(3);

            var responseText = JsonSerializer.Serialize(response, new JsonSerializerOptions
            {
                WriteIndented = true
            });
            
            Console.WriteLine(responseText);
        }
    }
}