using MediatR;

namespace Works.DeveloperEvaluation.Application.Assuntos.DeletarAssunto;

/// <summary>
/// Command for deleting a project
/// </summary>
public record DeletarAssuntoCommand : IRequest<DeletarAssuntoResponse>
{
    /// <summary>
    /// The unique identifier of the project to delete
    /// </summary>
    public int CodAs { get; }

    /// <summary>
    /// Initializes a new instance of DeleteProjectCommand
    /// </summary>
    /// <param name="id">The ID of the project to delete</param>
    public DeletarAssuntoCommand(int id)
    {
        CodAs = id;
    }
}
