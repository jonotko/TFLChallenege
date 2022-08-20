using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace TFLChallenge
{
    public class TflApiClient: ITflApiClient
    {

        private readonly HttpClient httpClient;

        public TflApiClient(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<RoadStatusAPIResponse> GetRoadStatusFor(string roadName)
        {
            //Console.WriteLine("GetRoadStatusFor");

            try
            {
            var response = await this.httpClient.GetFromJsonAsync<List<RoadStatus>>($"Road/{roadName}/Status");

                //Console.WriteLine(response);

                if (response.Count == 0)
                {
                    throw new Exception("Empty Response");
                }

                var apiResponse = new RoadStatusAPIResponse(true, response);
                //var jsonResponse = await response.Content.ReadFromJsonAsync<RoadStatus[]>();
                //foreach (RoadStatus i in response)
                //{
                //    Console.WriteLine("in loop");
                //    Console.WriteLine(i.displayName);
                //}
             return apiResponse;

            }
            catch
            {
                //Console.WriteLine(e);
               
                return new RoadStatusAPIResponse(false, null);

            }

            
            //var jsonResponse = await test.Content.ReadAsStringAsync();

            
        }
    }
}
