namespace Works.DeveloperEvaluation.Application.Livros.ListarLivro;

public class RelatorioLivroResult
{
    public int? CodL { get; set; }
    public string? Titulo { get; set; } = string.Empty;
    public string? Editora { get; set; } = string.Empty;
    public int? Edicao { get; set; }
    public string? AnoPublicacao { get; set; } = string.Empty;
    public string? Assunto { get; set; } = string.Empty;
    public string? Autor { get; set; } = string.Empty;
}
