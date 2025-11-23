using Works.DeveloperEvaluation.Domain.Enums;
namespace Works.DeveloperEvaluation.WebApi.Features.Autores.ListarAutor;

/// <summary>
/// API response model for ListProject operation
/// </summary>
public class ListarAutorResponse
{
    public int CodAu { get; set; }
    public string Nome { get; set; } = string.Empty;
   
}
