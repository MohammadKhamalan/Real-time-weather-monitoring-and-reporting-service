using Moq;
using Newtonsoft.Json;
using Real_time_weather_monitoring_and_reporting_service.WeatherMonitoringSystem.Models;
using Real_time_weather_monitoring_and_reporting_service.WeatherMonitoringSystem.Utilities;
using Xunit;
using FluentAssertions;

namespace WeatherMonitoringSystem.Tests
{
    public class JsonWeatherDataConverterTests
    {
        private readonly JsonWeatherDataConverter _converter = new JsonWeatherDataConverter();

        [Fact]
        public void Convert_ValidJson_ReturnsWeatherData()
        {
            // Arrange
            var json = "{\"Location\":\"Test\",\"Temperature\":25.5,\"Humidity\":60.0}";

            // Act
            var result = _converter.Convert(json);

            // Assert
            result.Should().NotBeNull();
            result.Location.Should().Be("Test");
            result.Temperature.Should().Be(25.5);
            result.Humidity.Should().Be(60.0);
        }

        [Fact]
        public void Convert_InvalidJson_ReturnsNull()
        {
            // Arrange
            var invalidJson = "{invalid}";

            // Act
            var result = _converter.Convert(invalidJson);

            // Assert
            result.Should().BeNull();
        }

        [Fact]
        public void Convert_EmptyJson_ReturnsNull()
        {
            // Arrange
            var emptyJson = "";

            // Act
            var result = _converter.Convert(emptyJson);

            // Assert
            result.Should().BeNull();
        }
    }
}
