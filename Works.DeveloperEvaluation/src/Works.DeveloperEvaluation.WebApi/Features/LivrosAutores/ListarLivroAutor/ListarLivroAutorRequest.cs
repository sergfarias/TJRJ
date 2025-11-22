namespace Works.DeveloperEvaluation.WebApi.Features.LivrosAutores.ListarLivroAutor;

/// <summary>
/// Represents a request to List as Projects in the system.
/// </summary>
public class ListarLivroAutorRequest
{
    public int Livro_CodL { get; set; }
    public int Autor_CodAu { get; set; }
}