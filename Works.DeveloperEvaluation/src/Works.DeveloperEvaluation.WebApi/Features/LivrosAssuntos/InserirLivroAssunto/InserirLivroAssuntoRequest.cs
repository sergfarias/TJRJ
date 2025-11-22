using Works.DeveloperEvaluation.Domain.Enums;
namespace Works.DeveloperEvaluation.WebApi.Features.LivrosAssuntos.InserirLivroAssunto;

/// <summary>
/// Represents a request to create a new project in the system.
/// </summary>
public class InserirLivroAssuntoRequest
{
    public int Livro_CodL { get; set; }
    public int Assunto_CodAs { get; set; }
    
}