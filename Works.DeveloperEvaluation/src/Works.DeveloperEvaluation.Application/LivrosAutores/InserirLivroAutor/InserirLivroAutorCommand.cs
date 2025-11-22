using MediatR;

namespace Works.DeveloperEvaluation.Application.LivrosAutores.InserirLivroAutor;

/// <summary>
/// Command for creating a new project.
/// </summary>
public class InserirLivroAutorCommand : IRequest<InserirLivroAutorResult>
{
    public int Livro_CodL { get; set; }
    public int Assunto_CodAs { get; set; }
}