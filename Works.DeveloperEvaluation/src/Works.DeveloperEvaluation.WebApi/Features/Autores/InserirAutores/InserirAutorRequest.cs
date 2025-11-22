using Works.DeveloperEvaluation.Domain.Enums;
namespace Works.DeveloperEvaluation.WebApi.Features.Autores.InserirAutor;

/// <summary>
/// Represents a request to create a new project in the system.
/// </summary>
public class InserirAutorRequest
{
    public string Nome { get; set; } = string.Empty;
   
}