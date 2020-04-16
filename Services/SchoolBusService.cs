using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using EweDash.Models;

namespace EweDash.Services
{
    public class SchoolBusService
    {
        HttpClient client = new HttpClient();
        String token = System.IO.File.ReadAllText(@"C:\Projects\Ewe Dash\SchoolBusService.txt");

        public async Task<List<SchoolBusModel>> GetSchoolBusInfoAsync()
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var data = new List<SchoolBusModel>(); 
            HttpResponseMessage response = await client.GetAsync("https://api.twitter.com/1.1/statuses/user_timeline.json?screen_name=OttSchoolBus&count=5");
            if (response.IsSuccessStatusCode)
            {
                data = response.Content.ReadAsAsync<List<SchoolBusModel>>().Result;
            }
            return data;
        }
    }

}
