using Works.DeveloperEvaluation.Domain.Enums;
namespace Works.DeveloperEvaluation.WebApi.Features.Autores.AlterarAutor;

/// <summary>
/// Represents a request to Modified a project in the system.
/// </summary>
public class AlterarAutorRequest
{
    public int CodAu { get; set; }
    public string Nome { get; set; } = string.Empty;
   

}