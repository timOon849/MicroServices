using Microsoft.AspNetCore.Mvc;

namespace MicroServices.Controllers
{
    public class FullController : Controller
    {
        private readonly HttpClient _httpClient;

        public FullController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var response = await _httpClient.GetStringAsync("http://localhost:5118");
            return Ok($"Response from Service A: {response}");
        }

    }
}
