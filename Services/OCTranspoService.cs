using System;
using System.Threading.Tasks;
using RestSharp;
using System.Threading;

namespace EweDash.Services
{
    public class OCTranspoService
    {

        String ocTranspoURL = System.IO.File.ReadAllText(@"C:\Projects\Ewe Dash\OCTranspo.txt");

        public async Task<IRestResponse> GetOCTranspoAsync()
        {
            var client = new RestClient(ocTranspoURL);
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            var cancellationTokenSource = new CancellationTokenSource();
            var restResponse = await client.ExecuteAsync(request, cancellationTokenSource.Token);
            return restResponse;
        }
    }
}
