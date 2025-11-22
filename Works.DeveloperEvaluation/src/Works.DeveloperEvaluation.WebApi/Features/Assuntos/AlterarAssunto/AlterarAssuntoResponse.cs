using Works.DeveloperEvaluation.Domain.Enums;
namespace Works.DeveloperEvaluation.WebApi.Features.Assuntos.AlterarAssunto;

/// <summary>
/// API response model for ModifiedProject operation
/// </summary>
public class AlterarAssuntoResponse
{
    public int CodAs { get; set; }
    public string Descricao { get; set; } = string.Empty;
    
}
