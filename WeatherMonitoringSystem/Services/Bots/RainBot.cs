using Real_time_weather_monitoring_and_reporting_service.WeatherMonitoringSystem.Interfaces;
using Real_time_weather_monitoring_and_reporting_service.WeatherMonitoringSystem.Models;

namespace Real_time_weather_monitoring_and_reporting_service.WeatherMonitoringSystem.Services.Bots
{
    public class RainBot : IWeatherObserver
    {
        private readonly double threshold;
        private readonly string message;

        public RainBot(double Threshold, string Message)
        {
            threshold = Threshold;
            message = Message;
        }

        public void Activated(WeatherData data)
        {
            if (data.Humidity > threshold)
            {
                Console.WriteLine("RainBot activated!");
                Console.WriteLine($"RainBot:{message}");
            }

        }
    }
}
