using AutoMapper;
using Works.DeveloperEvaluation.Application.Livros.ListarLivro;
using Works.DeveloperEvaluation.Application.Livros.RelatorioLivro;
namespace Works.DeveloperEvaluation.WebApi.Features.Livros.RelatorioLivro;

/// <summary>
/// Profile for mapping ListProject feature requests to commands
/// </summary>
public class RelatorioLivroProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for ListProject feature
    /// </summary>
    public RelatorioLivroProfile()
    {
        CreateMap<RelatorioLivroResult, RelatorioLivroResponse>();
        CreateMap<RelatorioLivroRequest, RelatorioLivroCommand>();
    }
}
