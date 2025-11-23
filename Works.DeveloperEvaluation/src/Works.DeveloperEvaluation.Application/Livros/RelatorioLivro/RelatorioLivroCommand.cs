using MediatR;
using Works.DeveloperEvaluation.Application.Livros.ListarLivro;
namespace Works.DeveloperEvaluation.Application.Livros.RelatorioLivro;

/// <summary>
/// Command for list a project.
/// </summary>
public class RelatorioLivroCommand : IRequest<List<RelatorioLivroResult>>
{
    public int CodL { get; set; }

}