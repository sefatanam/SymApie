using System;
using System.Threading.Tasks;
using IntegrationTextProxyApi.Cli.Api;
using IntegrationTextProxyApi.Cli.Output;
using IntegrationTextProxyApi.Cli.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Refit;

namespace IntegrationTextProxyApi.Cli
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var configuration = BuildConfiguration();
            var serviceProvider = BuildServiceProvider(configuration);
            var app = serviceProvider.GetRequiredService<CustomerSearchApplication>();
            await app.RunAsync(args);

            // var client = serviceProvider.GetRequiredService<ICustomerApi>();
            // var response = await client.SearchByIdAsync(3);
            // var responseText = JsonSerializer.Serialize(response, new JsonSerializerOptions
            // {
            //     WriteIndented = true
            // });
            // Console.WriteLine(responseText);
        }

        private static ServiceProvider BuildServiceProvider(IConfigurationRoot configuration)
        {
            var services = new ServiceCollection();
            ConfigureServices(services, configuration);

            var serviceProvider = services.BuildServiceProvider();
            return serviceProvider;
        }

        private static void ConfigureServices(IServiceCollection services, IConfigurationRoot configuration)
        {
            // Entry Point through IContainer
            services.AddSingleton<CustomerSearchApplication>();

            services.AddSingleton<IConsoleWriter, ConsoleWriter>();
            services.AddSingleton<ICustomerSearchService, CustomerSearchService>();

            services.AddRefitClient<ICustomerApi>()
                .ConfigureHttpClient(client =>
                {
                    client.BaseAddress = new Uri(configuration["CustomerApi:BaseAddress"]);
                });
        }

        private static IConfigurationRoot BuildConfiguration()
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();
            return configuration;
        }
    }
}