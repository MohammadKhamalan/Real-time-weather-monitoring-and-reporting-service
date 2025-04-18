using FluentAssertions;
using Moq;
using Newtonsoft.Json;
using Real_time_weather_monitoring_and_reporting_service.WeatherMonitoringSystem.Models;
using Real_time_weather_monitoring_and_reporting_service.WeatherMonitoringSystem.Models.Enums;
using Real_time_weather_monitoring_and_reporting_service.WeatherMonitoringSystem.Services;
using Xunit;

namespace WeatherMonitoringSystem.Tests
{
    public class BotConfigurationLoaderTests
    {
        [Fact]
        public void LoadFromFile_ValidJson_ReturnsConfigurations()
        {
            // Arrange
            var tempFilePath = Path.GetTempFileName();
            var jsonContent = @"{
        ""RainBot"": { ""Enabled"": true, ""Threshold"": 70, ""Message"": ""Rain msg"" },
        ""SunBot"": { ""Enabled"": true, ""Threshold"": 30, ""Message"": ""Sun msg"" }
    }";
            File.WriteAllText(tempFilePath, jsonContent);

            // Act
            var result = BotConfigurationLoader.LoadFromFile(tempFilePath);

            // Assert
            result.Count.Should().Be(2);
            result.Should().ContainKey(WeatherBotType.RainBot);
            result.Should().ContainKey(WeatherBotType.SunBot);
            result[WeatherBotType.RainBot].Threshold.Should().Be(70);
            result[WeatherBotType.RainBot].Message.Should().Be("Rain msg");

            // Cleanup
            File.Delete(tempFilePath);
        }
        [Fact]
        public void LoadFromFile_InvalidFile_ReturnsEmptyDictionary()
        {
            // Arrange
            var tempFilePath = Path.GetTempFileName();
            File.WriteAllText(tempFilePath, "invalid json");

            // Act
            var result = BotConfigurationLoader.LoadFromFile(tempFilePath);

            // Assert
            result.Should().BeEmpty();

            // Cleanup
            File.Delete(tempFilePath);
        }
        [Fact]
        public void LoadFromFile_NonExistentFile_ReturnsEmptyDictionary()
        {
            // Act
            var result = BotConfigurationLoader.LoadFromFile("nonexistent.json");

            // Assert
            result.Should().BeEmpty();
        }
    }
}