using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BingMapXyrilleMamalateoNew
{
    public class WeatherArea
    {
        public string Latitude { get; set; }

        public string Longitude { get; set; }
        public CurrentWeather Currently { get; set; }
    }

    public class CurrentWeather
    {
        public string Summary { get; set; }

        public string Icon { get; set; }

        public string Temperature { get; set; }

        public string Humidity { get; set; }

        public string WindSpeed { get; set; }
    }
}