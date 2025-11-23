using Works.DeveloperEvaluation.Domain.Enums;
namespace Works.DeveloperEvaluation.WebApi.Features.Autores.InserirAutor;

/// <summary>
/// API response model for CreateProject operation
/// </summary>
public class GetAutorResponse
{
    public int CodAu { get; set; }
    public string Nome { get; set; } = string.Empty;
   
}
