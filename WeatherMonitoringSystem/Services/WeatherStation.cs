using Real_time_weather_monitoring_and_reporting_service.WeatherMonitoringSystem.Interfaces;
using Real_time_weather_monitoring_and_reporting_service.WeatherMonitoringSystem.Models;
namespace Real_time_weather_monitoring_and_reporting_service.WeatherMonitoringSystem.Services
{
    public class WeatherStation : IWeatherProcess
    {
        private readonly List<IWeatherObserver> observers;

        public WeatherStation(List<IWeatherObserver> _observers)
        {
            observers = _observers;
        }
        public void ProcessWeatherData(string inputData, IWeatherDataParser parser)
        {
            var data = parser.Convert(inputData);
            NotifyBots(data);
        }

        private void NotifyBots(WeatherData data)
        {
            foreach (var observer in observers)
            {
                observer.Activated(data);
            }
        }
    }
}
