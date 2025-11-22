namespace Works.DeveloperEvaluation.WebApi.Features.LivrosAssuntos.DeletarLivroAssunto;

/// <summary>
/// Request model for deleting a project
/// </summary>
public class DeletarLivroAssuntoRequest
{
    /// <summary>
    /// The unique identifier of the project to delete
    /// </summary>
    public int Livro_CodL { get; set; }
    public int Assunto_CodAs { get; set; }
}
