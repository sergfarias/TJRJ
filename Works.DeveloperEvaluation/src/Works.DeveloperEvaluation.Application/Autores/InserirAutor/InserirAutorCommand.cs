using MediatR;

namespace Works.DeveloperEvaluation.Application.Autores.InserirAutor;

/// <summary>
/// Command for creating a new project.
/// </summary>
public class InserirAutorCommand : IRequest<InserirAutorResult>
{
    public string Nome { get; set; } = string.Empty;
    
}