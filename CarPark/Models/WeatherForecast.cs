using System.Text.Json.Serialization;

namespace CarPark.Models
{
    public class WeatherForecast
    {
        [JsonPropertyName("temp")]
        public int Temperature { get; set; }

        [JsonPropertyName("feels_like")]
        public int FeelsLike { get; set; }
    }

}
