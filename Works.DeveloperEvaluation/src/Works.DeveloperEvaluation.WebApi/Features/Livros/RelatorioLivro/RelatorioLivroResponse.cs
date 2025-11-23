using Works.DeveloperEvaluation.Domain.Enums;
namespace Works.DeveloperEvaluation.WebApi.Features.Livros.RelatorioLivro;

/// <summary>
/// API response model for ListProject operation
/// </summary>
public class RelatorioLivroResponse
{
    public int? CodL { get; set; }
    public string Titulo { get; set; } = string.Empty;
    public string Editora { get; set; } = string.Empty;
    public int? Edicao { get; set; }
    public string AnoPublicacao { get; set; } = string.Empty;
    public string Assunto { get; set; } = string.Empty;
    public string Autor { get; set; } = string.Empty;
}
