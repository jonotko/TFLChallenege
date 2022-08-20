using System;
using System.Net.Http;

namespace TFLChallenge
{
    public static class TflApiClientFactory
    {
        public static ITflApiClient Create(string baseAddress)
        {
            var httpClient = new HttpClient
            {
                BaseAddress = new Uri(baseAddress)
            };
            return new TflApiClient(httpClient);
         }
        
    }
}
