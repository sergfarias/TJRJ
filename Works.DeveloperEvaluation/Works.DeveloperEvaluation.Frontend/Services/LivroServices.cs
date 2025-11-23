using Works.DeveloperEvaluation.WebApi.Features.Livros.ListarLivro;
using System.Collections;
using System.Text;
using System.Text.Json;
using Livro = Works.DeveloperEvaluation.Frontend.Models.Livro;
using Works.DeveloperEvaluation.WebApi.Features.Livros.RelatorioLivro;

namespace Works.DeveloperEvaluation.Frontend.Services
{
    public class LivroServices: ILivroServices
    {

        readonly HttpClient _httpClient;
        private readonly JsonSerializerOptions _jsonOptions;

        private const string ApiBaseUrl = "https://localhost:7181/";


        public LivroServices(HttpClient httpClient)
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
            var response = await _httpClient.GetAsync("api/livros/TodosLivros");
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();

            // Se o JSON tem uma estrutura como: { "data": [...], "success": true }
            using JsonDocument document = JsonDocument.Parse(content);
            JsonElement root = document.RootElement;

            // Pegar o nó específico "data"
            JsonElement dataElement = root.GetProperty("data").GetProperty("data");

            var teste = JsonSerializer.Deserialize<IEnumerable<ListarLivroResponse>>(
                dataElement.GetRawText(),
                _jsonOptions
            );

            return teste;

        }

        public async Task<ListarLivroResponse> GetByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"api/livros/LivroById/{id}");
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();

            // Se o JSON tem uma estrutura como: { "data": [...], "success": true }
            using JsonDocument document = JsonDocument.Parse(content);
            JsonElement root = document.RootElement;

            // Pegar o nó específico "data"
            JsonElement dataElement = root.GetProperty("data").GetProperty("data");

            var teste = JsonSerializer.Deserialize<ListarLivroResponse>(
                dataElement.GetRawText(),
                _jsonOptions
            );

            return teste;
        }

        public async Task<ListarLivroResponse> CreateAsync(Livro livro)
        {
            var json = JsonSerializer.Serialize(livro);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("api/livros/InserirLivro", content);
            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync();


            // Se o JSON tem uma estrutura como: { "data": [...], "success": true }
            using JsonDocument document = JsonDocument.Parse(responseContent);
            JsonElement root = document.RootElement;

            // Pegar o nó específico "data"
            JsonElement dataElement = root.GetProperty("data");

            var teste = JsonSerializer.Deserialize<ListarLivroResponse>(
                dataElement.GetRawText(),
                _jsonOptions
            );

            return teste;


            //return JsonSerializer.Deserialize<IEnumerable>(responseContent, _jsonOptions);
        }

        public async Task UpdateAsync(int id, Livro livro)
        {
            var json = JsonSerializer.Serialize(livro);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PutAsync($"api/livros/alterarlivro", content);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/livros/deletarlivro/{id}");
            response.EnsureSuccessStatusCode();
        }


        public async Task<IEnumerable> Relatorio()
        {
            var response = await _httpClient.GetAsync("api/livros/RelatorioLivros");
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();

            // Se o JSON tem uma estrutura como: { "data": [...], "success": true }
            using JsonDocument document = JsonDocument.Parse(content);
            JsonElement root = document.RootElement;

            // Pegar o nó específico "data"
            JsonElement dataElement = root.GetProperty("data").GetProperty("data");

            var teste = JsonSerializer.Deserialize<IEnumerable<RelatorioLivroResponse>>(
                dataElement.GetRawText(),
                _jsonOptions
            );

            return teste;

        }



    }
}

