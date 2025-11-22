using AutoMapper;
using Works.DeveloperEvaluation.Application.Livros.ListarLivro;
namespace Works.DeveloperEvaluation.WebApi.Features.Livros.ListarLivro;

/// <summary>
/// Profile for mapping ListProject feature requests to commands
/// </summary>
public class ListarLivroProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for ListProject feature
    /// </summary>
    public ListarLivroProfile()
    {
        CreateMap<ListarLivroResult, ListarLivroResponse>();
        CreateMap<ListarLivroRequest, ListarLivroCommand>();
    }
}
