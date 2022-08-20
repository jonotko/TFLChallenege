using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TFLChallengeTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public async Task TestMainValidRoad()
        {
         
            using (var sw = new StringWriter())
            {

                Console.SetOut(sw);
                string[] args = { "A2" };
                await TFLChallenge.Program.Main(args);

                var result = sw.ToString();
                
                Assert.IsTrue(result.Contains($"The status of the {args[0]}"));
                Assert.IsTrue(result.Contains("Road Status"));
                Assert.IsTrue(result.Contains("Road Status Description"));

            }
            
        }

        [TestMethod]
        public async Task TestMainInValidRoad()
        {

            using (var sw = new StringWriter())
            {

                Console.SetOut(sw);
                string[] args = { "A233" };
                await TFLChallenge.Program.Main(args);

                var result = sw.ToString();

                Assert.IsTrue(result.Contains($"{args[0]} is not a valid road"));
                
            }

        }

        [TestMethod]
        public void TestApiFactory()
        {
            
            var baseUrl = "https://api.tfl.gov.uk";
            var tflapiclient = TFLChallenge.TflApiClientFactory.Create(baseUrl);

            Assert.IsInstanceOfType(tflapiclient, typeof(TFLChallenge.TflApiClient));
            

        }

        [TestMethod]
        public async Task TestRoadStatusForValidRoad()
        {
            
            var baseUrl = "https://api.tfl.gov.uk";
            var tflapiclient = TFLChallenge.TflApiClientFactory.Create(baseUrl);

            var road = "A2";
            
            var response = await tflapiclient.GetRoadStatusFor(road);

            Assert.IsTrue(response.Success);
           


        }

        [TestMethod]
        public async Task TestRoadStatusForInvalidRoad()
        {

            var baseUrl = "https://api.tfl.gov.uk";
            var tflapiclient = TFLChallenge.TflApiClientFactory.Create(baseUrl);

            var road = "A233";

            var response = await tflapiclient.GetRoadStatusFor(road);

            Assert.IsFalse(response.Success);



        }
    }
}
