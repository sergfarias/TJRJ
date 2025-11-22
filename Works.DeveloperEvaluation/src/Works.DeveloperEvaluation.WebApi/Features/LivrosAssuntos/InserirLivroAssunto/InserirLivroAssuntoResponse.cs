using Works.DeveloperEvaluation.Domain.Enums;
namespace Works.DeveloperEvaluation.WebApi.Features.LivrosAssuntos.InserirLivroAssunto;

/// <summary>
/// API response model for CreateProject operation
/// </summary>
public class GetLivroAssuntoResponse
{
    public int Livro_CodL { get; set; }
    public int Assunto_CodAs { get; set; }
}
