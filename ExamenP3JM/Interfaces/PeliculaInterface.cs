using ExamenP3JM.Models;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace ExamenP3JM.Interfaces
{
    public class PeliculaInterface : IPeliculaInterface
    {
        private string urlApi = "https://freetestapi.com/api/v1/movies?";
        public async Task<List<Pelicula>> Obtener()
        {
            var client = new HttpClient();
            var response = await client.GetAsync(urlApi);
            var responseBody = await response.Content.ReadAsStringAsync();
            JsonNode resultsNode = JsonNode.Parse(responseBody);
            var peliculasData = JsonSerializer.Deserialize<List<Pelicula>>(resultsNode.ToString());
            return peliculasData;

        }
    }
}
