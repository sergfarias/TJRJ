using Works.DeveloperEvaluation.Domain.Enums;
namespace Works.DeveloperEvaluation.WebApi.Features.Assuntos.AlterarAssunto;

/// <summary>
/// Represents a request to Modified a project in the system.
/// </summary>
public class AlterarAssuntoRequest
{
    public int CodAs { get; set; }
    public string Descricao { get; set; } = string.Empty;
   
}