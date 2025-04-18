using Real_time_weather_monitoring_and_reporting_service.WeatherMonitoringSystem.Interfaces;
using Real_time_weather_monitoring_and_reporting_service.WeatherMonitoringSystem.Models;
using System.Text.Json;

namespace Real_time_weather_monitoring_and_reporting_service.WeatherMonitoringSystem.Utilities
{
    public class JsonWeatherDataConverter : IWeatherDataParser
    {
        public WeatherData Convert(string InputData)
        {
            try
            {
                return JsonSerializer.Deserialize<WeatherData>(InputData);
            }
            catch (JsonException ex)
            {
                Console.WriteLine($"Error: Failed to deserialize JSON. {ex.Message}");
                return null;
            }
        }
    }
}
