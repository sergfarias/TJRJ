using AutoMapper;
using Works.DeveloperEvaluation.Application.LivrosAutores.InserirLivroAutor;
namespace Works.DeveloperEvaluation.WebApi.Features.LivrosAutores.InserirLivroAutor;

/// <summary>
/// Profile for mapping between Application and API CreateProject responses
/// </summary>
public class InserirLivroAutorProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for CreateProject feature
    /// </summary>
    public InserirLivroAutorProfile()
    {
        CreateMap<InserirLivroAutorRequest, InserirLivroAutorCommand>();
        CreateMap<InserirLivroAutorResult, GetLivroAutorResponse>();
    }
}
