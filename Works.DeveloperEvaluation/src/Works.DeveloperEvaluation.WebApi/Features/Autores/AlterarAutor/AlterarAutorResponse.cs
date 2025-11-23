using Works.DeveloperEvaluation.Domain.Enums;
namespace Works.DeveloperEvaluation.WebApi.Features.Autores.AlterarAutor;

/// <summary>
/// API response model for ModifiedProject operation
/// </summary>
public class AlterarAutorResponse
{
    public int CodAu { get; set; }
    public string Nome { get; set; } = string.Empty;
   
}
