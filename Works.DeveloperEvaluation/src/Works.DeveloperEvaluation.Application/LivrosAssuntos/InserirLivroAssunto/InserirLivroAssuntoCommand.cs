using MediatR;

namespace Works.DeveloperEvaluation.Application.LivrosAssuntos.InserirLivroAssunto;

/// <summary>
/// Command for creating a new project.
/// </summary>
public class InserirLivroAssuntoCommand : IRequest<InserirLivroAssuntoResult>
{
    public int Livro_CodL { get; set; }
    public int Assunto_CodAs { get; set; }
}