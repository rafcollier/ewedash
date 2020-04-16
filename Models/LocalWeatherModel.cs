using System.Collections.Generic;

namespace EweDash.Models

{
    public class LocalWeatherModel
    {
        public List<WeatherObject> Weather { get; set; }
        public MainObject Main { get; set; }

    }

    public class WeatherObject
    {
        public string Description { get; set; }
        public string Icon { get; set; }

    }

    public class MainObject
    {
        public float Temp { get; set; }

        public float Feels_like { get; set; }

    }


}
