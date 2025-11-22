using AutoMapper;
using Works.DeveloperEvaluation.Application.LivrosAssuntos.ListarLivroAssunto;
namespace Works.DeveloperEvaluation.WebApi.Features.LivrosAssuntos.ListarLivroAssunto;

/// <summary>
/// Profile for mapping ListProject feature requests to commands
/// </summary>
public class ListarLivroAssuntoProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for ListProject feature
    /// </summary>
    public ListarLivroAssuntoProfile()
    {
        CreateMap<ListarLivroAssuntoResult, ListarLivroAssuntoResponse>();
        CreateMap<ListarLivroAssuntoRequest, ListarLivroAssuntoCommand>();
    }
}
