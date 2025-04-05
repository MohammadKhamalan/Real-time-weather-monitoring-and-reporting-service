using Real_time_weather_monitoring_and_reporting_service.WeatherMonitoringSystem.Interfaces;
using Real_time_weather_monitoring_and_reporting_service.WeatherMonitoringSystem.Models;
using Real_time_weather_monitoring_and_reporting_service.WeatherMonitoringSystem.Models.Enums;
using Real_time_weather_monitoring_and_reporting_service.WeatherMonitoringSystem.Services.Bots;
using WeatherMonitoringSystem.Interfaces;

namespace Real_time_weather_monitoring_and_reporting_service.WeatherMonitoringSystem.Utilities
{
   public class WeatherBotFactory : IWeatherBotFactory
    {
        private readonly Dictionary<WeatherBotType, BotConfiguration> botTypeConfiguration;
        public WeatherBotFactory(Dictionary<WeatherBotType, BotConfiguration> botTypeConfiguration)
        {
            this.botTypeConfiguration = botTypeConfiguration;
        }

        public IWeatherObserver CreateBot(WeatherBotType botType)
        {
            if (!botTypeConfiguration.ContainsKey(botType))
                throw new ArgumentException("Invalid bot type");
            var config = botTypeConfiguration[botType];

            return botType switch
            {
                WeatherBotType.RainBot => new RainBot(config.Threshold, config.Message),
                WeatherBotType.SnowBot => new SnowBot(config.Threshold, config.Message),
                WeatherBotType.SunBot => new SunBot(config.Threshold, config.Message),
                _ => throw new ArgumentException("Invalid bot type")
            };

        }

        }
    }

