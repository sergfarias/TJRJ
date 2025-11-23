using Works.DeveloperEvaluation.Domain.Enums;
namespace Works.DeveloperEvaluation.WebApi.Features.Autores.BuscarAutor;

/// <summary>
/// API response model for ListProject operation
/// </summary>
public class BuscarAutorResponse
{
    public int CodAu { get; set; }
    public string Nome { get; set; } = string.Empty;
   
}
