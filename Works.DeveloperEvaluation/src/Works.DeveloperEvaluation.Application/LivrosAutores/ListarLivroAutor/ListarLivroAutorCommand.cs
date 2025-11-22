using MediatR;
namespace Works.DeveloperEvaluation.Application.LivrosAutores.ListarLivroAutor;

/// <summary>
/// Command for list a project.
/// </summary>
public class ListarLivroAutorCommand : IRequest<List<ListarLivroAutorResult>>
{
    public int Livro_Codl { get; set; }

}