using System;
using System.Threading.Tasks;
using System.Net.Http;
using EweDash.Models;

namespace EweDash.Services
{
    public class LocalWeatherService
    {
        HttpClient client = new HttpClient();
        String weatherURL = System.IO.File.ReadAllText(@"C:\Projects\Ewe Dash\LocalWeather.txt");

        public async Task<LocalWeatherModel> GetWeatherAsync()
        {
            LocalWeatherModel localWeather = new LocalWeatherModel();
            HttpResponseMessage response = await client.GetAsync(weatherURL);
            if (response.IsSuccessStatusCode)
            {
                localWeather = await response.Content.ReadAsAsync<LocalWeatherModel>();
            }
            return localWeather;
        }
    }
}
