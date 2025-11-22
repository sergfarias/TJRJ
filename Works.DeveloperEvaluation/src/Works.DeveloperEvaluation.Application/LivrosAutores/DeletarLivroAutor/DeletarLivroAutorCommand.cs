using MediatR;

namespace Works.DeveloperEvaluation.Application.LivrosAutores.DeletarLivroAutor;

/// <summary>
/// Command for deleting a project
/// </summary>
public record DeletarLivroAutorCommand : IRequest<DeletarLivroAutorResponse>
{
    /// <summary>
    /// The unique identifier of the project to delete
    /// </summary>
    public int Livro_CodL { get; }
    public int Autor_CodAu { get; }

    /// <summary>
    /// Initializes a new instance of DeleteProjectCommand
    /// </summary>
    /// <param name="id">The ID of the project to delete</param>
    public DeletarLivroAutorCommand(int id, int id2)
    {
        Livro_CodL = id;
        Autor_CodAu = id2;
    }
}
