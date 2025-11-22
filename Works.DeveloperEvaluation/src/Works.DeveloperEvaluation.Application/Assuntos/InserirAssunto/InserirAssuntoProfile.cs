using AutoMapper;
using Works.DeveloperEvaluation.Domain.Entities;

namespace Works.DeveloperEvaluation.Application.Assuntos.InserirAssunto;

/// <summary>
/// Profile for mapping between sale entity and CreateProjectResponse
/// </summary>
public class InserirAssuntoProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for CreateProject operation
    /// </summary>
    public InserirAssuntoProfile()
    {
        CreateMap<InserirAssuntoCommand, Assunto>();
        CreateMap<Assunto, InserirAssuntoResult>();
    }
}
