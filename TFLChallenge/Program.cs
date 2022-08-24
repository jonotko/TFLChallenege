using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace TFLChallenge
{
    public class Program
    {


        public static async Task Main(string[] args)
        {
            string road;
            if(args.Length == 0)
            {
                Console.WriteLine("Enter a road to begin");
                road = Console.ReadLine();
            }
            else
            {
                road = args[0];
            }

            await FetchRoadStatus(road);

        }

        public static async Task FetchRoadStatus(string road)
        {
            //Console.WriteLine("Fetching start");
            var baseUrl = "https://api.tfl.gov.uk";
            var client = TflApiClientFactory.Create(baseUrl);
            //var road = "AA3";
            
            //Console.WriteLine("Client created");

            var response = await client.GetRoadStatusFor(road);

            //Console.WriteLine("status returned");

            //Console.WriteLine(response.Success);

            if(response.Success)
            {
                var roadStatus = response.JsonResponse[0];

                Console.WriteLine($"The status of the {roadStatus.displayName} is as follows");
                Console.WriteLine($"Road Status is {roadStatus.statusSeverity}");
                Console.WriteLine($"Road Status Description is {roadStatus.statusSeverityDescription}");
            
            }
            else
            {
                Console.WriteLine($"{road} is not a valid road");
            };

      
        }
        
    }
}
