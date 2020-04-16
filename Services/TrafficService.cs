using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using EweDash.Models;

namespace EweDash.Services
{
    public class TrafficService
    {
        HttpClient client = new HttpClient();
        List<TrafficModel> trafficData = new List<TrafficModel>();
        String token = System.IO.File.ReadAllText(@"C:\Projects\Ewe Dash\TrafficService.txt");

        public async Task<List<TrafficModel>> GetTrafficInfoAsync()
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var data1 = new List<TrafficModel>();
            var data2 = new List<TrafficModel>();
            var data3 = new List<TrafficModel>();

            HttpResponseMessage response1 = await client.GetAsync("https://api.twitter.com/1.1/statuses/user_timeline.json?screen_name=Ottawa_Traffic&count=1");
            if (response1.IsSuccessStatusCode)
            {
                data1 = response1.Content.ReadAsAsync<List<TrafficModel>>().Result;
            }

            HttpResponseMessage response2 = await client.GetAsync("https://api.twitter.com/1.1/statuses/user_timeline.json?screen_name=cbcotttraffic&count=1");
            if (response2.IsSuccessStatusCode)
            {
                data2 = response2.Content.ReadAsAsync<List<TrafficModel>>().Result;
            }

            HttpResponseMessage response3 = await client.GetAsync("https://api.twitter.com/1.1/statuses/user_timeline.json?screen_name=1310traffic&count=1");
            if (response3.IsSuccessStatusCode)
            {
                data3 = response3.Content.ReadAsAsync<List<TrafficModel>>().Result;
            }

            trafficData = data1.Concat(data2).Concat(data3).ToList();

            return trafficData;
        }
    }

}
