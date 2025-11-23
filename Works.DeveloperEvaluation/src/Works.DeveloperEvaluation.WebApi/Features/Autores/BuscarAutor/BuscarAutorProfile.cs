using AutoMapper;
using Works.DeveloperEvaluation.Application.Autores.BuscarAutor;
namespace Works.DeveloperEvaluation.WebApi.Features.Autores.BuscarAutor;

/// <summary>
/// Profile for mapping ListProject feature requests to commands
/// </summary>
public class BuscarAutorProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for ListProject feature
    /// </summary>
    public BuscarAutorProfile()
    {
        CreateMap<BuscarAutorResult, BuscarAutorResponse>();
        CreateMap<BuscarAutorRequest, BuscarAutorCommand>();
    }
}
