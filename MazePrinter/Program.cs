using Microsoft.Extensions.Configuration;

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