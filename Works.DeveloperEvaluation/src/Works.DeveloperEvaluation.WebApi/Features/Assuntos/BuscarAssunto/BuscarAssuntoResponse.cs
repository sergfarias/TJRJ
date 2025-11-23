using Works.DeveloperEvaluation.Domain.Enums;
namespace Works.DeveloperEvaluation.WebApi.Features.Assuntos.BuscarAssunto;

/// <summary>
/// API response model for ListProject operation
/// </summary>
public class BuscarAssuntoResponse
{
    public int CodAs { get; set; }
    public string Descricao { get; set; } = string.Empty;
   
}
