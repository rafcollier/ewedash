using System;
using System.Threading.Tasks;
using RestSharp;
using System.Threading;

namespace EweDash.Services
{
    public class NetflixService
    {
        public async Task<IRestResponse> GetNetflixAsync()
        {
            String netflixAPI = System.IO.File.ReadAllText(@"C:\Projects\Ewe Dash\Netflix.txt");
            var client = new RestClient("https://unogs-unogs-v1.p.rapidapi.com/aaapi.cgi?q=get%3Anew7%3ACA&p=1&t=ns&st=adv");
            var request = new RestRequest(Method.GET);
            request.AddHeader("x-rapidapi-host", "unogs-unogs-v1.p.rapidapi.com");
            request.AddHeader("x-rapidapi-key", netflixAPI);
            var cancellationTokenSource = new CancellationTokenSource();
            var restResponse = await client.ExecuteAsync(request, cancellationTokenSource.Token);
            return restResponse;

        }
    }


}
