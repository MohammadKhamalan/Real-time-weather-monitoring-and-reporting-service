using Real_time_weather_monitoring_and_reporting_service.WeatherMonitoringSystem.Interfaces;

namespace Real_time_weather_monitoring_and_reporting_service.WeatherMonitoringSystem.Menu
{
    public class MainMenu
    {
        private readonly IWeatherProcess WeatherProcess;
        private readonly IWeatherDataParser JsonParser;
        private readonly IWeatherDataParser XmlParser;

        public MainMenu(IWeatherProcess weatherProcess, IWeatherDataParser jsonParser, IWeatherDataParser xmlParser)
        {
            WeatherProcess = weatherProcess;
            JsonParser = jsonParser;
            XmlParser = xmlParser;
        }

        public void ShowMenu()
        {

            while (true)
            {
                Console.WriteLine("Welcome To The weather monitoring and reporting service system");
                Console.WriteLine("1. Enter weather data");
                Console.WriteLine("2. Exit");
                Console.Write("Please choose an option (1 or 2): ");

                var choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        Console.WriteLine("Enter weather data(JSON or XML):");
                        var inputData = Console.ReadLine();
                        IWeatherDataParser Converter = SelectFormatConverter(inputData);
                        WeatherProcess.ProcessWeatherData(inputData, Converter);
                        break;
                    case "2":
                        Console.WriteLine("Exiting the application");
                        return;
                    default:
                        Console.WriteLine("PLease enter a valid option");
                        break;
                       

                }
               
            }
        }
        public IWeatherDataParser SelectFormatConverter(string inputData)
        {
            if (string.IsNullOrWhiteSpace(inputData))
                throw new ArgumentException("Error: Input data cannot be empty or null.");

            string trimmedInput = inputData.TrimStart();
            if (trimmedInput.StartsWith("{"))
                return JsonParser;
            if (trimmedInput.StartsWith("<"))
                return XmlParser;

            throw new ArgumentException("Unsupported data format");
        }
    }
}