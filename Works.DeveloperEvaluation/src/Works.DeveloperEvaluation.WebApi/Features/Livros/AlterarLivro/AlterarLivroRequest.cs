using Works.DeveloperEvaluation.Domain.Enums;
namespace Works.DeveloperEvaluation.WebApi.Features.Livros.AlterarLivro;

/// <summary>
/// Represents a request to Modified a project in the system.
/// </summary>
public class AlterarLivroRequest
{
    public int CodL { get; set; }
    public string Titulo { get; set; } = string.Empty;
    public string Editora { get; set; } = string.Empty;
    public int Edicao { get; set; }
    public string AnoPublicacao { get; set; } = string.Empty;
    public List<Domain.Entities.Autor> Autores { get; set; } = [];
    public List<Domain.Entities.Assunto> Assuntos { get; set; } = [];

}