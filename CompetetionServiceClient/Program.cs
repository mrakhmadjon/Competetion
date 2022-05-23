

using PlayerReference;
using System;
using System.Threading.Tasks;

namespace CompetetionServiceClient
{
    internal class Program
    {
        static async Task Main(string[] args)
        {

            
            HelloWorldRequest helloWorld = new HelloWorldRequest();
            HelloWorldResponse helloWorldResponse = new HelloWorldResponse();
            //PlayerReference.PlayerServiceSoapClient client = new PlayerReference.PlayerServiceSoapClient();
           
            var service = new PlayerReference.HelloWorldRequestBody();
            var config = new PlayerServiceSoapClient.EndpointConfiguration();
            var client = new PlayerReference.PlayerServiceSoapClient(config);
            var result = await client.HelloWorldAsync();
            Console.WriteLine(result.Body.HelloWorldResult);
        }
    }
}
