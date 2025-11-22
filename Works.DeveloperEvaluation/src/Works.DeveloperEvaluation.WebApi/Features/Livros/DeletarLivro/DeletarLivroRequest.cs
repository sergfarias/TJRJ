namespace Works.DeveloperEvaluation.WebApi.Features.Livros.DeletarLivro;

/// <summary>
/// Request model for deleting a project
/// </summary>
public class DeletarLivroRequest
{
    /// <summary>
    /// The unique identifier of the project to delete
    /// </summary>
    public int CodL { get; set; }
}
