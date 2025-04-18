using Moq;
using Real_time_weather_monitoring_and_reporting_service.WeatherMonitoringSystem.Interfaces;
using Real_time_weather_monitoring_and_reporting_service.WeatherMonitoringSystem.Models;
using Real_time_weather_monitoring_and_reporting_service.WeatherMonitoringSystem.Services;
using Xunit;
using FluentAssertions;

namespace WeatherMonitoringSystem.Tests
{
    public class WeatherStationTests
    {
        [Fact]
        public void ProcessWeatherData_ValidData_NotifiesAllObservers()
        {
            // Arrange
            var mockObserver1 = new Mock<IWeatherObserver>();
            var mockObserver2 = new Mock<IWeatherObserver>();
            var mockParser = new Mock<IWeatherDataParser>();

            var weatherData = new WeatherData { Location = "Test", Temperature = 25, Humidity = 60 };
            mockParser.Setup(p => p.Convert(It.IsAny<string>())).Returns(weatherData);

            var observers = new List<IWeatherObserver> { mockObserver1.Object, mockObserver2.Object };
            var weatherStation = new WeatherStation(observers);

            // Act
            weatherStation.ProcessWeatherData("test data", mockParser.Object);

            // Assert
            mockObserver1.Verify(o => o.Activated(weatherData), Times.Once);
            mockObserver2.Verify(o => o.Activated(weatherData), Times.Once);
        }

        [Fact]
        public void ProcessWeatherData_NullData_NotifiesObserversWithNull()
        {
            // Arrange
            var mockObserver = new Mock<IWeatherObserver>();
            var mockParser = new Mock<IWeatherDataParser>();

            mockParser.Setup(p => p.Convert(It.IsAny<string>())).Returns((WeatherData)null);

            var observers = new List<IWeatherObserver> { mockObserver.Object };
            var weatherStation = new WeatherStation(observers);

            // Act
            weatherStation.ProcessWeatherData("invalid data", mockParser.Object);

            // Assert
            mockObserver.Verify(o => o.Activated(null), Times.Once);
        }
    }
}
