using AutoMapper;
using Works.DeveloperEvaluation.Domain.Entities;

namespace Works.DeveloperEvaluation.Application.LivrosAssuntos.InserirLivroAssunto;

/// <summary>
/// Profile for mapping between sale entity and CreateProjectResponse
/// </summary>
public class InserirLivroAssuntoProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for CreateProject operation
    /// </summary>
    public InserirLivroAssuntoProfile()
    {
        CreateMap<InserirLivroAssuntoCommand, LivroAssunto>();
        CreateMap<LivroAssunto, InserirLivroAssuntoResult>();
    }
}
