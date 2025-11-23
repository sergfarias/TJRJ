using Works.DeveloperEvaluation.WebApi.Features.Autores.ListarAutor;
using System.Collections;
using System.Text;
using System.Text.Json;
using Autor =Works.DeveloperEvaluation.Frontend.Models.Autor;

namespace Works.DeveloperEvaluation.Frontend.Services
{
    public class AutorServices : IAutorServices
    {

        readonly HttpClient _httpClient;
        private readonly JsonSerializerOptions _jsonOptions;

        private const string ApiBaseUrl = "https://localhost:7181/";


        public AutorServices(HttpClient httpClient)
        {
            _httpClient = httpClient;

            _httpClient.BaseAddress = new Uri(ApiBaseUrl);
            _httpClient.DefaultRequestHeaders.Add("Accept", "application/json");

            _jsonOptions = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
        }

        public async Task<IEnumerable> GetAllAsync()
        {
            var response = await _httpClient.GetAsync("api/autores/TodosAutores");
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();

            // Se o JSON tem uma estrutura como: { "data": [...], "success": true }
            using JsonDocument document = JsonDocument.Parse(content);
            JsonElement root = document.RootElement;

            // Pegar o nó específico "data"
            JsonElement dataElement = root.GetProperty("data").GetProperty("data");

            var teste = JsonSerializer.Deserialize<IEnumerable<ListarAutorResponse>>(
                dataElement.GetRawText(),
                _jsonOptions
            );

            return teste;
        }

        public async Task<ListarAutorResponse> GetByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"api/autores/AutorById/{id}");
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();

            // Se o JSON tem uma estrutura como: { "data": [...], "success": true }
            using JsonDocument document = JsonDocument.Parse(content);
            JsonElement root = document.RootElement;

            // Pegar o nó específico "data"
            JsonElement dataElement = root.GetProperty("data").GetProperty("data");

            var teste = JsonSerializer.Deserialize<ListarAutorResponse>(
                dataElement.GetRawText(),
                _jsonOptions
            );

            return teste;
        }

        public async Task<ListarAutorResponse> CreateAsync(Autor autor)
        {
            var json = JsonSerializer.Serialize(autor);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("api/Autores/InserirAutor", content);
            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync();


            // Se o JSON tem uma estrutura como: { "data": [...], "success": true }
            using JsonDocument document = JsonDocument.Parse(responseContent);
            JsonElement root = document.RootElement;

            // Pegar o nó específico "data"
            JsonElement dataElement = root.GetProperty("data");

            var teste = JsonSerializer.Deserialize<ListarAutorResponse>(
                dataElement.GetRawText(),
                _jsonOptions
            );

            return teste;


            //return JsonSerializer.Deserialize<IEnumerable>(responseContent, _jsonOptions);
        }

        public async Task UpdateAsync(int id, Autor autor)
        {
            var json = JsonSerializer.Serialize(autor);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PutAsync($"api/Autores/alterarAutor", content);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/autores/deletarAutor/{id}");
            response.EnsureSuccessStatusCode();
        }
    }
}

