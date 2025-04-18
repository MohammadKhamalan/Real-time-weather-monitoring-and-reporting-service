using Real_time_weather_monitoring_and_reporting_service.WeatherMonitoringSystem.Interfaces;
using Real_time_weather_monitoring_and_reporting_service.WeatherMonitoringSystem.Models.Enums;

namespace WeatherMonitoringSystem.Interfaces
{
    public interface IWeatherBotFactory
    {
        IWeatherObserver CreateBot(WeatherBotType botType);
    }
}
