namespace Works.DeveloperEvaluation.WebApi.Features.Assuntos.DeletarAssunto;

/// <summary>
/// Request model for deleting a project
/// </summary>
public class DeletarAssuntoRequest
{
    /// <summary>
    /// The unique identifier of the project to delete
    /// </summary>
    public int CodAs { get; set; }
}
