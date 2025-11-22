using MediatR;

namespace Works.DeveloperEvaluation.Application.Livros.DeletarLivro;

/// <summary>
/// Command for deleting a project
/// </summary>
public record DeletarLivroCommand : IRequest<DeletarLivroResponse>
{
    /// <summary>
    /// The unique identifier of the project to delete
    /// </summary>
    public int CodL { get; }

    /// <summary>
    /// Initializes a new instance of DeleteProjectCommand
    /// </summary>
    /// <param name="id">The ID of the project to delete</param>
    public DeletarLivroCommand(int id)
    {
        CodL = id;
    }
}
