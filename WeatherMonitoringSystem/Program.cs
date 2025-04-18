using Real_time_weather_monitoring_and_reporting_service.WeatherMonitoringSystem.Menu;
using Real_time_weather_monitoring_and_reporting_service.WeatherMonitoringSystem.Services;
using Real_time_weather_monitoring_and_reporting_service.WeatherMonitoringSystem.Utilities;

class Program
{
    static void Main()
    {
        string jsonFilePath = "C:\\Users\\ASUS\\Desktop\\Real-time weather monitoring and reporting service\\WeatherMonitoringSystem\\Configuration\\botsConfig.json";
        var botConfig = BotConfigurationLoader.LoadFromFile(jsonFilePath);
        var botFactory = new WeatherBotFactory(botConfig);
        var botAvailable = botConfig.Keys.Where(botType => botConfig[botType].Enabled).Select(botFactory.CreateBot).ToList();

        var weatherStation = new WeatherStation(botAvailable);
        var jsonConverter = new JsonWeatherDataConverter();
        var xmlConverter = new XmlWeatherDataConverter();
        var menu = new MainMenu(weatherStation, jsonConverter, xmlConverter);
        menu.ShowMenu();
    }
}
