using Works.DeveloperEvaluation.Domain.Enums;
namespace Works.DeveloperEvaluation.WebApi.Features.LivrosAutores.InserirLivroAutor;

/// <summary>
/// API response model for CreateProject operation
/// </summary>
public class GetLivroAutorResponse
{
    public int Livro_CodL { get; set; }
    public int Autor_CodAs { get; set; }
}
