using Newtonsoft.Json;
using Real_time_weather_monitoring_and_reporting_service.WeatherMonitoringSystem.Models;
using Real_time_weather_monitoring_and_reporting_service.WeatherMonitoringSystem.Models.Enums;

namespace Real_time_weather_monitoring_and_reporting_service.WeatherMonitoringSystem.Services
{
    public static class BotConfigurationLoader
    {
        public static Dictionary<WeatherBotType, BotConfiguration> LoadFromFile(string filePath)
        {
            var result = new Dictionary<WeatherBotType, BotConfiguration>();

            try
            {
                var json = File.ReadAllText(filePath);
                var configs = JsonConvert.DeserializeObject<Dictionary<string, BotConfiguration>>(json);

                foreach (var config in configs)
                {
                    if (Enum.TryParse(config.Key, out WeatherBotType botType))
                    {
                        result[botType] = config.Value;
                    }
                }
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine($"Error: The file at path '{filePath}' was not found. {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
            }

            return result;
        }
    }
}
