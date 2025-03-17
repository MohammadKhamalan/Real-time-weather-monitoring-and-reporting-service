using Real_time_weather_monitoring_and_reporting_service.WeatherMonitoringSystem.Interfaces;
using Real_time_weather_monitoring_and_reporting_service.WeatherMonitoringSystem.Models;
using System.Xml.Serialization;

namespace Real_time_weather_monitoring_and_reporting_service.WeatherMonitoringSystem.Utilities
{
    class XmlWeatherDataConverter : IWeatherDataParser
    {
        public WeatherData Convert(string InputData)
        {
            try
            {
                var serializer = new XmlSerializer(typeof(WeatherData));
                using (var reader = new StringReader(InputData))
                {
                    return (WeatherData)serializer.Deserialize(reader);
                }
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"Error: Failed to deserialize XML. {ex.Message}");
                return null;

            }
        }
    }
}
