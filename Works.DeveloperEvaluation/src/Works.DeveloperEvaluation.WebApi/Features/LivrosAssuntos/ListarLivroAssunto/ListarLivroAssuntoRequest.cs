namespace Works.DeveloperEvaluation.WebApi.Features.LivrosAssuntos.ListarLivroAssunto;

/// <summary>
/// Represents a request to List as Projects in the system.
/// </summary>
public class ListarLivroAssuntoRequest
{
    public int Livro_CodL { get; set; }
    public int Assunto_CodAs { get; set; }
}