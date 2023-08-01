using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using Domain.MazeGenerator;

namespace MazePrinter
{
    public class MazeAPIInterface
    {
        private readonly JsonSerializerOptions serializerOptions;

        public HttpClient client = new HttpClient();
        public string ApiUrl = string.Empty;
        public MazeAPIInterface(string url)
        {
            ApiUrl = url;

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            serializerOptions = new JsonSerializerOptions();
            serializerOptions.PropertyNameCaseInsensitive = true;
            serializerOptions.Converters.Add(new TwoDimensionalIntArrayJsonConverter());
        }

        public async Task<Maze> GetMaze(int mazeHeight, int mazeWidth)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync($"{ApiUrl}/MazeGeneration/GetMaze?mazeHeight={mazeHeight}&mazeWidth={mazeWidth}", 0);

            if (response.IsSuccessStatusCode)
            {
                //TODO: Solve this problem
                //I know it's ridiculous but I couldn't make it work by just desserializing directly to Maze
                //Neither with ReadFromString or ReadFromStream.
                var aux = await response.Content.ReadFromJsonAsync<object>();
                return JsonSerializer.Deserialize<Maze>(aux.ToString(), options: serializerOptions);
            }

            return null;
        }
    }
}