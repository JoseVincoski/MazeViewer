using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace HttpClientSample
{
    public class ConsoleInterface
    {
        private MazeAPIInterface mazeApi;
        public ConsoleInterface(MazeAPIInterface apiInterface)
        {
            mazeApi = apiInterface;
        }

        public async Task Start()
        {
            var maze = await mazeApi.GetMaze(5,5);
            var b = 1;
        }
    }
}