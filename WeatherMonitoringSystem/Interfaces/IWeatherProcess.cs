namespace Real_time_weather_monitoring_and_reporting_service.WeatherMonitoringSystem.Interfaces
{
    public interface IWeatherProcess
    {
        void ProcessWeatherData(string inputData, IWeatherDataParser Convert);
    }
}
