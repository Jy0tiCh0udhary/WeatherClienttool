using Newtonsoft.Json;
using System;
using System.Threading.Tasks;
using WeatherClientTool.Model;

namespace WeatherClientTool
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.Write("Enter a city name: ");
            string? cityName = Console.ReadLine();

            string jsonFileContent = File.ReadAllText("cities.json");
            List<CityData> cityList = JsonConvert.DeserializeObject<List<CityData>>(jsonFileContent);
            CityData? city = cityList.FirstOrDefault(c => c.City.Equals(cityName, StringComparison.OrdinalIgnoreCase));

            if (city != null)
            {
                decimal latitude = city.Latitude;
                decimal longitude = city.Longitude;
                WeatherData weatherData = await FetchWeatherData(latitude, longitude);
                Console.WriteLine($"Temperature: {weatherData.CurrentWeather.Temperature}");
                Console.WriteLine($"Windspeed: {weatherData.CurrentWeather.Windspeed}");
            }
            else
            {
                Console.WriteLine("City not found.");
            }         

        }

        public static async Task<WeatherData> FetchWeatherData(decimal latitude, decimal longitude)
        {
            string apiUrl = $"https://api.open-meteo.com/v1/forecast?latitude={latitude}&longitude={longitude}&current_weather=true";

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(apiUrl);
                string jsonResponse = await response.Content.ReadAsStringAsync();
                WeatherData weatherData = JsonConvert.DeserializeObject<WeatherData>(jsonResponse);

                return weatherData;
            }
        }

    }

}

