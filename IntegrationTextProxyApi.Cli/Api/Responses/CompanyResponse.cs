using System.Text.Json.Serialization;

namespace IntegrationTextProxyApi.Cli.Api.Responses
{
    public class CompanyResponse
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
    
        [JsonPropertyName("catchPhrase")]
        public string CatchPhrase { get; set; }
    
        [JsonPropertyName("bs")]
        public string Bs { get; set; }
    }
}