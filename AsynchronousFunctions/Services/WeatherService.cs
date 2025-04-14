namespace AsynchronousFunctions.Services
{
    public class WeatherService
    {
        private readonly HttpClient _httpClient;

        public WeatherService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> GetWeatherAsync()
        {
            var response = await _httpClient.GetAsync($"https://api.open-meteo.com/v1/forecast?latitude=35&longitude=139&hourly=temperature_2m\r\n");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }
    }
}
