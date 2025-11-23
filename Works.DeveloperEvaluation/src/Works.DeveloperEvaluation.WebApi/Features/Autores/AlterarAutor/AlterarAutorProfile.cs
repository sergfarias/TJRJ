using AutoMapper;
using Works.DeveloperEvaluation.Application.Autores.AlterarAutor;
namespace Works.DeveloperEvaluation.WebApi.Features.Autores.AlterarAutor;

/// <summary>
/// Profile for mapping between Application and API ModifiedProject responses
/// </summary>
public class AlterarAutorProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for ModifiedProject feature
    /// </summary>
    public AlterarAutorProfile()
    {
        CreateMap<AlterarAutorRequest, AlterarAutorCommand>();
        CreateMap<AlterarAutorResult, AlterarAutorResponse>();
    }
}
