using AutoMapper;
using Works.DeveloperEvaluation.Application.Autores.InserirAutor;
namespace Works.DeveloperEvaluation.WebApi.Features.Autores.InserirAutor;

/// <summary>
/// Profile for mapping between Application and API CreateProject responses
/// </summary>
public class InserirAutorProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for CreateProject feature
    /// </summary>
    public InserirAutorProfile()
    {
        CreateMap<InserirAutorRequest, InserirAutorCommand>();
        CreateMap<InserirAutorResult, GetAutorResponse>();
    }
}
