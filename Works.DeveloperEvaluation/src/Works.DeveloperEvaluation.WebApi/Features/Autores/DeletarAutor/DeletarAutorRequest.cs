namespace Works.DeveloperEvaluation.WebApi.Features.Autores.DeletarAutor;

/// <summary>
/// Request model for deleting a project
/// </summary>
public class DeletarAutorRequest
{
    /// <summary>
    /// The unique identifier of the project to delete
    /// </summary>
    public int CodAu { get; set; }
}
