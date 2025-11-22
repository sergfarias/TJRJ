using MediatR;
namespace Works.DeveloperEvaluation.Application.LivrosAssuntos.ListarLivroAssunto;

/// <summary>
/// Command for list a project.
/// </summary>
public class ListarLivroAssuntoCommand : IRequest<List<ListarLivroAssuntoResult>>
{
    public int Livro_Codl { get; set; }

}