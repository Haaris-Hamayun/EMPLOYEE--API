using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace EMPLOYEE_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherHistoryController : ControllerBase
    {
        private readonly HttpClient _httpClient;

        // Put your actual OpenWeatherMap API key here
        private readonly string apiKey = "abcdef1234567890abcdef1234567890";

        public WeatherHistoryController(HttpClient httpClient)
        {
            _httpClient = httpClient;

            // Request JSON responses from the API
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        // GET api/weatherhistory?lat=xx&lon=yy&timestamp=zz
        [HttpGet]
        public async Task<IActionResult> GetWeatherHistory([FromQuery] double lat, [FromQuery] double lon, [FromQuery] long timestamp)
        {
            // Validate latitude and longitude
            if (lat < -90 || lat > 90 || lon < -180 || lon > 180)
                return BadRequest("Latitude must be between -90 and 90, and longitude between -180 and 180.");

            // Validate timestamp (must be within last 5 days)
            var now = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
            if (timestamp < now - 432000 || timestamp > now)
                return BadRequest("Timestamp must be within the last 5 days.");

            // Build API URL with query parameters and API key
            string url = $"https://api.openweathermap.org/data/3.0/onecall/timemachine?lat={lat}&lon={lon}&dt={timestamp}&appid={apiKey}&units=metric";

            // Call the OpenWeatherMap API
            var response = await _httpClient.GetAsync(url);

            // If call fails, return error status and message
            if (!response.IsSuccessStatusCode)
            {
                string errorDetails = await response.Content.ReadAsStringAsync();
                return StatusCode((int)response.StatusCode, $"Failed to fetch data: {errorDetails}");
            }

            // Read JSON response content
            var jsonData = await response.Content.ReadAsStringAsync();

            // Return JSON data to the client
            return Ok(JsonConvert.DeserializeObject(jsonData));
        }
    }
}
