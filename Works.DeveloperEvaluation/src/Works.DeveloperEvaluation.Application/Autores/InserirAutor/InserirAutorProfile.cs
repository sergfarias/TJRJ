using AutoMapper;
using Works.DeveloperEvaluation.Domain.Entities;

namespace Works.DeveloperEvaluation.Application.Autores.InserirAutor;

/// <summary>
/// Profile for mapping between sale entity and CreateProjectResponse
/// </summary>
public class InserirAutorProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for CreateProject operation
    /// </summary>
    public InserirAutorProfile()
    {
        CreateMap<InserirAutorCommand, Autor>();
        CreateMap<Autor, InserirAutorResult>();
    }
}
