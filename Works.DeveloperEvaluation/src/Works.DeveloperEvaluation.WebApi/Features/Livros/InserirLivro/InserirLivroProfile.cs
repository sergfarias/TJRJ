using AutoMapper;
using Works.DeveloperEvaluation.Application.Livros.InserirLivro;
namespace Works.DeveloperEvaluation.WebApi.Features.Livros.InserirLivro;

/// <summary>
/// Profile for mapping between Application and API CreateProject responses
/// </summary>
public class InserirLivroProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for CreateProject feature
    /// </summary>
    public InserirLivroProfile()
    {
        CreateMap<InserirLivroRequest, InserirLivroCommand>();
        CreateMap<InserirLivroResult, GetLivroResponse>();
    }
}
