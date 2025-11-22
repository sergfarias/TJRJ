using AutoMapper;
using Works.DeveloperEvaluation.Application.LivrosAssuntos.InserirLivroAssunto;
namespace Works.DeveloperEvaluation.WebApi.Features.LivrosAssuntos.InserirLivroAssunto;

/// <summary>
/// Profile for mapping between Application and API CreateProject responses
/// </summary>
public class InserirLivroAssuntoProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for CreateProject feature
    /// </summary>
    public InserirLivroAssuntoProfile()
    {
        CreateMap<InserirLivroAssuntoRequest, InserirLivroAssuntoCommand>();
        CreateMap<InserirLivroAssuntoResult, GetLivroAssuntoResponse>();
    }
}
