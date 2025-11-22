using MediatR;

namespace Works.DeveloperEvaluation.Application.Autores.DeletarAutor;

/// <summary>
/// Command for deleting a project
/// </summary>
public record DeletarAutorCommand : IRequest<DeletarAutorResponse>
{
    /// <summary>
    /// The unique identifier of the project to delete
    /// </summary>
    public int CodAu { get; }

    /// <summary>
    /// Initializes a new instance of DeleteProjectCommand
    /// </summary>
    /// <param name="id">The ID of the project to delete</param>
    public DeletarAutorCommand(int id)
    {
        CodAu = id;
    }
}
