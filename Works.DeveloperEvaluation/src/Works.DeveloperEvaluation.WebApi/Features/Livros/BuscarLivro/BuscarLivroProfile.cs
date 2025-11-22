using AutoMapper;
using Works.DeveloperEvaluation.Application.Livros.BuscarLivro;
namespace Works.DeveloperEvaluation.WebApi.Features.Livros.BuscarLivro;

/// <summary>
/// Profile for mapping ListProject feature requests to commands
/// </summary>
public class BuscarLivroProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for ListProject feature
    /// </summary>
    public BuscarLivroProfile()
    {
        CreateMap<BuscarLivroResult, BuscarLivroResponse>();
        CreateMap<BuscarLivroRequest, BuscarLivroCommand>();
    }
}
