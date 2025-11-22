using AutoMapper;
using Works.DeveloperEvaluation.Domain.Entities;

namespace Works.DeveloperEvaluation.Application.LivrosAutores.InserirLivroAutor;

/// <summary>
/// Profile for mapping between sale entity and CreateProjectResponse
/// </summary>
public class InserirLivroAutorProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for CreateProject operation
    /// </summary>
    public InserirLivroAutorProfile()
    {
        CreateMap<InserirLivroAutorCommand, LivroAutor>();
        CreateMap<LivroAutor, InserirLivroAutorResult>();
    }
}
