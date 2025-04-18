using Moq;
using Real_time_weather_monitoring_and_reporting_service.WeatherMonitoringSystem.Interfaces;
using Real_time_weather_monitoring_and_reporting_service.WeatherMonitoringSystem.Models;
using Real_time_weather_monitoring_and_reporting_service.WeatherMonitoringSystem.Services.Bots;
using Xunit;
using FluentAssertions;

namespace WeatherMonitoringSystem.Tests
{
    public class WeatherBotTests
    {
        [Fact]
        public void RainBot_Activated_WhenHumidityAboveThreshold()
        {
            // Arrange
            var consoleOutput = new StringWriter();
            Console.SetOut(consoleOutput);

            var rainBot = new RainBot(70, "Rain message");
            var weatherData = new WeatherData { Humidity = 75 };

            // Act
            rainBot.Activated(weatherData);

            // Assert
            var output = consoleOutput.ToString();
            output.Should().Contain("RainBot activated!");
            output.Should().Contain("RainBot:Rain message");
        }

        [Fact]
        public void RainBot_NotActivated_WhenHumidityBelowThreshold()
        {
            // Arrange
            var consoleOutput = new StringWriter();
            Console.SetOut(consoleOutput);

            var rainBot = new RainBot(70, "Rain message");
            var weatherData = new WeatherData { Humidity = 65 };

            // Act
            rainBot.Activated(weatherData);

            // Assert
            var output = consoleOutput.ToString();
            output.Should().NotContain("RainBot activated!");
        }

        [Fact]
        public void SunBot_Activated_WhenTemperatureAboveThreshold()
        {
            // Arrange
            var consoleOutput = new StringWriter();
            Console.SetOut(consoleOutput);

            var sunBot = new SunBot(30, "Sun message");
            var weatherData = new WeatherData { Temperature = 35 };

            // Act
            sunBot.Activated(weatherData);

            // Assert
            var output = consoleOutput.ToString();
            output.Should().Contain("SunBot activated!");
            output.Should().Contain("SunBot:Sun message");
        }

        [Fact]
        public void SnowBot_Activated_WhenTemperatureBelowThreshold()
        {
            // Arrange
            var consoleOutput = new StringWriter();
            Console.SetOut(consoleOutput);

            var snowBot = new SnowBot(0, "Snow message");
            var weatherData = new WeatherData { Temperature = -5 };

            // Act
            snowBot.Activated(weatherData);

            // Assert
            var output = consoleOutput.ToString();
            output.Should().Contain("SnowBot activated!");
            output.Should().Contain("SnowBot:Snow message");
        }
    }
}
