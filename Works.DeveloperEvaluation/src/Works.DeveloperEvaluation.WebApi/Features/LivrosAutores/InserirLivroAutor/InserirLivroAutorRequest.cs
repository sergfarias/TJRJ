using Works.DeveloperEvaluation.Domain.Enums;
namespace Works.DeveloperEvaluation.WebApi.Features.LivrosAutores.InserirLivroAutor;

/// <summary>
/// Represents a request to create a new project in the system.
/// </summary>
public class InserirLivroAutorRequest
{
    public int Livro_CodL { get; set; }
    public int Autor_CodAs { get; set; }
    
}