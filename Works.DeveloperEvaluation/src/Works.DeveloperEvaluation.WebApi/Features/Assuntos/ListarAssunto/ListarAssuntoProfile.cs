using AutoMapper;
using Works.DeveloperEvaluation.Application.Assuntos.ListarAssunto;
namespace Works.DeveloperEvaluation.WebApi.Features.Assuntos.ListarAssunto;

/// <summary>
/// Profile for mapping ListProject feature requests to commands
/// </summary>
public class ListarAssuntoProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for ListProject feature
    /// </summary>
    public ListarAssuntoProfile()
    {
        CreateMap<ListarAssuntoResult, ListarAssuntoResponse>();
        CreateMap<ListarAssuntoRequest, ListarAssuntoCommand>();
    }
}
