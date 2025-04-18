using Moq;
using Real_time_weather_monitoring_and_reporting_service.WeatherMonitoringSystem.Interfaces;
using Real_time_weather_monitoring_and_reporting_service.WeatherMonitoringSystem.Models;
using Real_time_weather_monitoring_and_reporting_service.WeatherMonitoringSystem.Utilities;
using Xunit;
using FluentAssertions;

namespace WeatherMonitoringSystem.Tests
{
    public class XmlWeatherDataConverterTests
    {
        private readonly XmlWeatherDataConverter _converter = new XmlWeatherDataConverter();

        [Fact]
        public void Convert_ValidXml_ReturnsWeatherData()
        {
            // Arrange
            var xml = "<WeatherData><Location>Test</Location><Temperature>25.5</Temperature><Humidity>60.0</Humidity></WeatherData>";

            // Act
            var result = _converter.Convert(xml);

            // Assert
            result.Should().NotBeNull();
            result.Location.Should().Be("Test");
            result.Temperature.Should().Be(25.5);
            result.Humidity.Should().Be(60.0);
        }

        [Fact]
        public void Convert_InvalidXml_ReturnsNull()
        {
            // Arrange
            var invalidXml = "<invalid>";

            // Act
            var result = _converter.Convert(invalidXml);

            // Assert
            result.Should().BeNull();
        }

        [Fact]
        public void Convert_EmptyString_ReturnsNull()
        {
            // Arrange
            var emptyXml = "";

            // Act
            var result = _converter.Convert(emptyXml);

            // Assert
            result.Should().BeNull();
        }
    }
}
