using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace MatanProject.Services
{
    public class DownloadManager
    {
        private HttpResponseMessage response;
        private Task<string> desResult;

        public async Task<string> SendCalculation(string url)
        {
            HttpClient client = new HttpClient();

            response = await client.GetAsync(url);

            desResult = response.Content.ReadAsStringAsync();

            return desResult.Result;
        }
    }
}
