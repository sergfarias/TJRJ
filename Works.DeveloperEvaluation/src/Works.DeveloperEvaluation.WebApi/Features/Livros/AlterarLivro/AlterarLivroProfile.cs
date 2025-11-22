using AutoMapper;
using Works.DeveloperEvaluation.Application.Livros.AlterarLivro;
namespace Works.DeveloperEvaluation.WebApi.Features.Livros.AlterarLivro;

/// <summary>
/// Profile for mapping between Application and API ModifiedProject responses
/// </summary>
public class AlterarLivroProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for ModifiedProject feature
    /// </summary>
    public AlterarLivroProfile()
    {
        CreateMap<AlterarLivroRequest, AlterarLivroCommand>();
        CreateMap<AlterarLivroResult, AlterarLivroResponse>();
    }
}
