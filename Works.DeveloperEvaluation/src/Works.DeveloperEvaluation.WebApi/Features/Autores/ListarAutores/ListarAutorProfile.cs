using AutoMapper;
using Works.DeveloperEvaluation.Application.Autores.ListarAutor;
namespace Works.DeveloperEvaluation.WebApi.Features.Autores.ListarAutor;

/// <summary>
/// Profile for mapping ListProject feature requests to commands
/// </summary>
public class ListarAutorProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for ListProject feature
    /// </summary>
    public ListarAutorProfile()
    {
        CreateMap<ListarAutorResult, ListarAutorResponse>();
        CreateMap<ListarAutorRequest, ListarAutorCommand>();
    }
}
