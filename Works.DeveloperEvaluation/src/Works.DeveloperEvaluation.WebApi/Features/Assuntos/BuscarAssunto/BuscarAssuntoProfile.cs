using AutoMapper;
using Works.DeveloperEvaluation.Application.Assuntos.BuscarAssunto;
namespace Works.DeveloperEvaluation.WebApi.Features.Assuntos.BuscarAssunto;

/// <summary>
/// Profile for mapping ListProject feature requests to commands
/// </summary>
public class BuscarAssuntoProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for ListProject feature
    /// </summary>
    public BuscarAssuntoProfile()
    {
        CreateMap<BuscarAssuntoResult, BuscarAssuntoResponse>();
        CreateMap<BuscarAssuntoRequest, BuscarAssuntoCommand>();
    }
}
