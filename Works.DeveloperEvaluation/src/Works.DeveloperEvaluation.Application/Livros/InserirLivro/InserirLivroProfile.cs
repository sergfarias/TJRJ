using AutoMapper;
using Works.DeveloperEvaluation.Domain.Entities;

namespace Works.DeveloperEvaluation.Application.Livros.InserirLivro;

/// <summary>
/// Profile for mapping between sale entity and CreateProjectResponse
/// </summary>
public class InserirLivroProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for CreateProject operation
    /// </summary>
    public InserirLivroProfile()
    {
        CreateMap<InserirLivroCommand, Livro>();
        CreateMap<Livro, InserirLivroResult>();
    }
}
