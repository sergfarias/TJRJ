namespace Works.DeveloperEvaluation.WebApi.Features.LivrosAutores.DeletarLivroAutor;

/// <summary>
/// Request model for deleting a project
/// </summary>
public class DeletarLivroAutorRequest
{
    /// <summary>
    /// The unique identifier of the project to delete
    /// </summary>
    public int Livro_CodL { get; set; }
    public int Autor_CodAu { get; set; }
}
