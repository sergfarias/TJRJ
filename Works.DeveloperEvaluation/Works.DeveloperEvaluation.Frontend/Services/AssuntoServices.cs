using Works.DeveloperEvaluation.WebApi.Features.Assuntos.ListarAssunto;
using System.Collections;
using System.Text;
using System.Text.Json;
using Assunto = Works.DeveloperEvaluation.Frontend.Models.Assunto;
using Works.DeveloperEvaluation.Domain.Entities;
using Works.DeveloperEvaluation.WebApi.Features.Assuntos.BuscarAssunto;

namespace Works.DeveloperEvaluation.Frontend.Services
{
    public class AssuntoServices : IAssuntoServices
    {

        readonly HttpClient _httpClient;
        private readonly JsonSerializerOptions _jsonOptions;

        private const string ApiBaseUrl = "https://localhost:7181/";


        public AssuntoServices(HttpClient httpClient)
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
            var response = await _httpClient.GetAsync("api/assuntos/TodosAssuntos");
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();

            // Se o JSON tem uma estrutura como: { "data": [...], "success": true }
            using JsonDocument document = JsonDocument.Parse(content);
            JsonElement root = document.RootElement;

            // Pegar o nó específico "data"
            JsonElement dataElement = root.GetProperty("data").GetProperty("data");

            var teste = JsonSerializer.Deserialize<IEnumerable<ListarAssuntoResponse>>(
                dataElement.GetRawText(),
                _jsonOptions
            );

            return teste;

        }

        public async Task<ListarAssuntoResponse> GetByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"api/assuntos/AssuntoById/{id}");
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();

            // Se o JSON tem uma estrutura como: { "data": [...], "success": true }
            using JsonDocument document = JsonDocument.Parse(content);
            JsonElement root = document.RootElement;

            // Pegar o nó específico "data"
            JsonElement dataElement = root.GetProperty("data").GetProperty("data");

            var teste = JsonSerializer.Deserialize<ListarAssuntoResponse>(
                dataElement.GetRawText(),
                _jsonOptions
            );

            return teste;
        }

        public async Task<ListarAssuntoResponse> CreateAsync(Assunto assunto)
        {
            var json = JsonSerializer.Serialize(assunto);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("api/assuntos/InserirAssunto", content);
            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync();


            // Se o JSON tem uma estrutura como: { "data": [...], "success": true }
            using JsonDocument document = JsonDocument.Parse(responseContent);
            JsonElement root = document.RootElement;

            // Pegar o nó específico "data"
            JsonElement dataElement = root.GetProperty("data");

            var teste = JsonSerializer.Deserialize<ListarAssuntoResponse>(
                dataElement.GetRawText(),
                _jsonOptions
            );

            return teste;


            //return JsonSerializer.Deserialize<IEnumerable>(responseContent, _jsonOptions);
        }

        public async Task UpdateAsync(int id, Assunto assunto)
        {
            var json = JsonSerializer.Serialize(assunto);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PutAsync($"api/assuntos/alterarAssunto", content);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/assuntos/deletarAssunto/{id}");
            response.EnsureSuccessStatusCode();
        }
    }
}

