using CarPark.Models;
using System.Text.Json;

namespace CarPark.Services
{
    public class WeatherForecastService
    {
        private readonly string _key;

        public WeatherForecastService(string key)
        {
            _key = key;
        }

        // Exponential backoff
        public async Task<WeatherForecast> GetAsync()
        {
            TimeSpan nextDelay = TimeSpan.FromSeconds(1);

            for (int i = 0; i < 3; i++)
            {
                try
                {
                    Console.WriteLine(i);
                    return await GetForecastAsync(_key);
                }
                catch
                { }

                await Task.Delay(nextDelay);
                nextDelay = nextDelay + nextDelay;
            }

            return await GetForecastAsync(_key);
        }

        private async Task<WeatherForecast> GetForecastAsync(string key)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
                httpClient.DefaultRequestHeaders.Add("x-rapidapi-ua", "RapidAPI-Playground");
                httpClient.DefaultRequestHeaders.Add("x-rapidapi-key", key);
                httpClient.DefaultRequestHeaders.Add("x-rapidapi-host", "weather-by-api-ninjas.p.rapidapi.com");

                using var response = await httpClient.GetAsync("https://weather-by-api-ninjas.p.rapidapi.com/v1/weather?lat=55.751244&lon=37.618423");
                var json = await response.Content.ReadAsStringAsync();
                response.EnsureSuccessStatusCode();
                WeatherForecast forecast = JsonSerializer.Deserialize<WeatherForecast>(json);

                return forecast;
            }
        }
    }
}
