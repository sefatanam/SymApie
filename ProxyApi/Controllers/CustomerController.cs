using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ProxyApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {

        [HttpGet]
        public async Task<IActionResult> Get()
        {

            try
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri("https://jsonplaceholder.typicode.com/users"),
                };
                using var response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                return Ok(body);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
          
        }
        [HttpGet("GetById")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {

            try
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri($"https://jsonplaceholder.typicode.com/users/{id}"),
                };
                using var response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                return Ok(body);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
          
        }
        

    }
}