using Works.DeveloperEvaluation.Domain.Enums;
namespace Works.DeveloperEvaluation.WebApi.Features.LivrosAutores.ListarLivroAutor;

/// <summary>
/// API response model for ListProject operation
/// </summary>
public class ListarLivroAutorResponse
{
    public int Livro_CodL { get; set; }
    public int Autor_CodAu { get; set; }
    
}
