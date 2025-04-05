using Moq;
using Real_time_weather_monitoring_and_reporting_service.WeatherMonitoringSystem.Interfaces;
using Real_time_weather_monitoring_and_reporting_service.WeatherMonitoringSystem.Models;
using Real_time_weather_monitoring_and_reporting_service.WeatherMonitoringSystem.Models.Enums;
using Real_time_weather_monitoring_and_reporting_service.WeatherMonitoringSystem.Utilities;
using Xunit;
using FluentAssertions;

namespace WeatherMonitoringSystem.Tests
{
    public class WeatherBotFactoryTests
    {
        private readonly Dictionary<WeatherBotType, BotConfiguration> _configs;
        private readonly WeatherBotFactory _factory;

        public WeatherBotFactoryTests()
        {
            _configs = new Dictionary<WeatherBotType, BotConfiguration>
            {
                { WeatherBotType.RainBot, new BotConfiguration { Enabled = true, Threshold = 70, Message = "Rain message" } },
                { WeatherBotType.SunBot, new BotConfiguration { Enabled = true, Threshold = 30, Message = "Sun message" } },
                { WeatherBotType.SnowBot, new BotConfiguration { Enabled = true, Threshold = 0, Message = "Snow message" } }
            };
            _factory = new WeatherBotFactory(_configs);
        }

        [Theory]
        [InlineData(WeatherBotType.RainBot)]
        [InlineData(WeatherBotType.SunBot)]
        [InlineData(WeatherBotType.SnowBot)]
        public void CreateBot_ValidBotType_ReturnsCorrectBot(WeatherBotType botType)
        {
            // Act
            var result = _factory.CreateBot(botType);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeAssignableTo<IWeatherObserver>();
        }

        [Fact]
        public void CreateBot_InvalidBotType_ThrowsArgumentException()
        {
            // Arrange
            var invalidBotType = (WeatherBotType)999;

            // Act & Assert
            Action act = () => _factory.CreateBot(invalidBotType);
            act.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void CreateBot_MissingConfiguration_ThrowsArgumentException()
        {
            // Arrange
            var emptyConfigs = new Dictionary<WeatherBotType, BotConfiguration>();
            var factory = new WeatherBotFactory(emptyConfigs);

            // Act & Assert
            Action act = () => factory.CreateBot(WeatherBotType.RainBot);
            act.Should().Throw<ArgumentException>();
        }
    }
}
