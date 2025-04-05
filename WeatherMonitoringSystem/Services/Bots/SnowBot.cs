using Real_time_weather_monitoring_and_reporting_service.WeatherMonitoringSystem.Interfaces;
using Real_time_weather_monitoring_and_reporting_service.WeatherMonitoringSystem.Models;

namespace Real_time_weather_monitoring_and_reporting_service.WeatherMonitoringSystem.Services.Bots
{
   public class SnowBot : IWeatherObserver
    {
        private readonly double threshold;
        private readonly string message;

        public SnowBot(double Threshold, string Message)
        {
            threshold = Threshold;
            message = Message;
        }

        public void Activated(WeatherData data)
        {
            if (data.Temperature < threshold)
            {
                Console.WriteLine("SnowBot activated!");
                Console.WriteLine($"SnowBot:{message}");
            }

        }
    }
}
