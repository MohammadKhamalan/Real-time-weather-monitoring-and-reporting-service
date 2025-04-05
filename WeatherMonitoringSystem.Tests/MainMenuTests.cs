using Moq;
using Real_time_weather_monitoring_and_reporting_service.WeatherMonitoringSystem.Interfaces;
using Real_time_weather_monitoring_and_reporting_service.WeatherMonitoringSystem.Menu;
using Real_time_weather_monitoring_and_reporting_service.WeatherMonitoringSystem.Models;
using Xunit;
using FluentAssertions;

namespace WeatherMonitoringSystem.Tests
{
    public class MainMenuTests
    {
        [Fact]
        public void SelectFormatConverter_JsonInput_ReturnsJsonParser()
        {
            // Arrange
            var mockWeatherProcess = new Mock<IWeatherProcess>();
            var mockJsonParser = new Mock<IWeatherDataParser>();
            var mockXmlParser = new Mock<IWeatherDataParser>();

            var menu = new MainMenu(mockWeatherProcess.Object, mockJsonParser.Object, mockXmlParser.Object);
            var jsonInput = "{ \"key\": \"value\" }";

            // Act
            var result = menu.SelectFormatConverter(jsonInput);

            // Assert
            result.Should().Be(mockJsonParser.Object);
        }

        [Fact]
        public void SelectFormatConverter_XmlInput_ReturnsXmlParser()
        {
            // Arrange
            var mockWeatherProcess = new Mock<IWeatherProcess>();
            var mockJsonParser = new Mock<IWeatherDataParser>();
            var mockXmlParser = new Mock<IWeatherDataParser>();

            var menu = new MainMenu(mockWeatherProcess.Object, mockJsonParser.Object, mockXmlParser.Object);
            var xmlInput = "<root></root>";

            // Act
            var result = menu.SelectFormatConverter(xmlInput);

            // Assert
            result.Should().Be(mockXmlParser.Object);
        }

        [Fact]
        public void SelectFormatConverter_InvalidInput_ThrowsArgumentException()
        {
            // Arrange
            var mockWeatherProcess = new Mock<IWeatherProcess>();
            var mockJsonParser = new Mock<IWeatherDataParser>();
            var mockXmlParser = new Mock<IWeatherDataParser>();

            var menu = new MainMenu(mockWeatherProcess.Object, mockJsonParser.Object, mockXmlParser.Object);
            var invalidInput = "plain text";

            // Act & Assert
            Action act = () => menu.SelectFormatConverter(invalidInput);
            act.Should().Throw<ArgumentException>();
        }
    }
}
