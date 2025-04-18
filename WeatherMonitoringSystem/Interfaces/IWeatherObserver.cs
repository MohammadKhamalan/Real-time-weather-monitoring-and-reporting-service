using Real_time_weather_monitoring_and_reporting_service.WeatherMonitoringSystem.Models;

namespace Real_time_weather_monitoring_and_reporting_service.WeatherMonitoringSystem.Interfaces
{
    public interface IWeatherObserver
    {
        void Activated(WeatherData data);
    }
}
