using AutoMapper;
using Works.DeveloperEvaluation.Application.Assuntos.InserirAssunto;
using Works.DeveloperEvaluation.Application.Livros.InserirLivro;
namespace Works.DeveloperEvaluation.WebApi.Features.Assuntos.InserirAssunto;

/// <summary>
/// Profile for mapping between Application and API CreateProject responses
/// </summary>
public class InserirAssuntoProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for CreateProject feature
    /// </summary>
    public InserirAssuntoProfile()
    {
        CreateMap<InserirAssuntoRequest, InserirAssuntoCommand>();
        CreateMap<InserirAssuntoResult, GetAssuntoResponse>();
    }
}
