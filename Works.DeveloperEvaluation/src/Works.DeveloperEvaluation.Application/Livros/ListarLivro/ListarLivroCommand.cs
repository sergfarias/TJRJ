using MediatR;
namespace Works.DeveloperEvaluation.Application.Livros.ListarLivro;

/// <summary>
/// Command for list a project.
/// </summary>
public class ListarLivroCommand : IRequest<List<ListarLivroResult>>
{
    public int Codl { get; set; }

}