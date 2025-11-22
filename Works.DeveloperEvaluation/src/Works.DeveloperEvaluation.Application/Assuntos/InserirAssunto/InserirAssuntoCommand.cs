using MediatR;

namespace Works.DeveloperEvaluation.Application.Assuntos.InserirAssunto;

/// <summary>
/// Command for creating a new project.
/// </summary>
public class InserirAssuntoCommand : IRequest<InserirAssuntoResult>
{
    public string Descricao { get; set; } = string.Empty;
    
}