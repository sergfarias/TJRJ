using Works.DeveloperEvaluation.Domain.Enums;
namespace Works.DeveloperEvaluation.WebApi.Features.Assuntos.ListarAssunto;

/// <summary>
/// API response model for ListProject operation
/// </summary>
public class ListarAssuntoResponse
{
    public int CodAs { get; set; }
    public string Descricao { get; set; } = string.Empty;
    
}
