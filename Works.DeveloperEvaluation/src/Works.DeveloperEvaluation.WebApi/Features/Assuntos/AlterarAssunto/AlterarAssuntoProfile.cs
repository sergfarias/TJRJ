using AutoMapper;
using Works.DeveloperEvaluation.Application.Assuntos.AlterarAssunto;
//using Works.DeveloperEvaluation.Application.Livros.AlterarLivro;
namespace Works.DeveloperEvaluation.WebApi.Features.Assuntos.AlterarAssunto;

/// <summary>
/// Profile for mapping between Application and API ModifiedProject responses
/// </summary>
public class AlterarAssuntoProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for ModifiedProject feature
    /// </summary>
    public AlterarAssuntoProfile()
    {
        CreateMap<AlterarAssuntoRequest, AlterarAssuntoCommand>();
        CreateMap<AlterarAssuntoResult, AlterarAssuntoResponse>();
    }
}
