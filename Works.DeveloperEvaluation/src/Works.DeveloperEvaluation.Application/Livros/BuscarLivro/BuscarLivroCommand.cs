using MediatR;
namespace Works.DeveloperEvaluation.Application.Livros.BuscarLivro;

/// <summary>
/// Command for list a project.
/// </summary>
public class BuscarLivroCommand : IRequest<BuscarLivroResult>
{
    public int Codl { get; set; }

}