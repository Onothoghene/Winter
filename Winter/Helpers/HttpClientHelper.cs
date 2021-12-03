using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Winter.Helpers
{
    public class HttpClientHelper
    {
        public HttpClient Initial()
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:44364/")
            };
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/Json"));
            return client;
        }

    }
}
