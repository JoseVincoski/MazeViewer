using HttpClientSample;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using System.Net.Http.Headers;

namespace MazePrinter
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
                   .AddJsonFile($"appsettings.json", true, true);

            var config = builder.Build();

            var console = new ConsoleInterface(new MazeAPIInterface(config["MazeAPIUrl"]));
            await console.Start();
        }
    }
}