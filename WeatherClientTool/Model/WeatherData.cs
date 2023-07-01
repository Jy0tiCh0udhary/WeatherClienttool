using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherClientTool.Model
{
    public class WeatherData
    {
        [JsonProperty("latitude")]
        public decimal Latitude { get; set; }

        [JsonProperty("longitude")]
        public decimal Longitude { get; set; }

        [JsonProperty("current_weather")]
        public CurrentWeatherData CurrentWeather { get; set; }
    }

    public class CurrentWeatherData
    {
        [JsonProperty("temperature")]
        public double Temperature { get; set; }

        [JsonProperty("windspeed")]
        public double Windspeed { get; set; }

    }

    public class CityData
    {
        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("lat")]
        public decimal Latitude { get; set; }

        [JsonProperty("lng")]
        public decimal Longitude { get; set; }
    }

}
