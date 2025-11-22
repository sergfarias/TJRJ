using Works.DeveloperEvaluation.Domain.Enums;
namespace Works.DeveloperEvaluation.WebApi.Features.Assuntos.InserirAssunto;

/// <summary>
/// Represents a request to create a new project in the system.
/// </summary>
public class InserirAssuntoRequest
{
    public string Descricao { get; set; } = string.Empty;
    
}