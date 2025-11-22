using MediatR;

namespace Works.DeveloperEvaluation.Application.LivrosAssuntos.DeletarLivroAssunto;

/// <summary>
/// Command for deleting a project
/// </summary>
public record DeletarLivroAssuntoCommand : IRequest<DeletarLivroAssuntoResponse>
{
    /// <summary>
    /// The unique identifier of the project to delete
    /// </summary>
    public int Livro_CodL { get; }
    public int Assunto_CodAs { get; }

    /// <summary>
    /// Initializes a new instance of DeleteProjectCommand
    /// </summary>
    /// <param name="id">The ID of the project to delete</param>
    public DeletarLivroAssuntoCommand(int id, int id2)
    {
        Livro_CodL = id;
        Assunto_CodAs = id2;
    }
}
