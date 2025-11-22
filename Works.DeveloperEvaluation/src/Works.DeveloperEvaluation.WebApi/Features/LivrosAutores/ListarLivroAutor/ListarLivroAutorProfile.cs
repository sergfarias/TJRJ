using AutoMapper;
using Works.DeveloperEvaluation.Application.LivrosAutores.ListarLivroAutor;
namespace Works.DeveloperEvaluation.WebApi.Features.LivrosAutores.ListarLivroAutor;

/// <summary>
/// Profile for mapping ListProject feature requests to commands
/// </summary>
public class ListarLivroAutorProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for ListProject feature
    /// </summary>
    public ListarLivroAutorProfile()
    {
        CreateMap<ListarLivroAutorResult, ListarLivroAutorResponse>();
        CreateMap<ListarLivroAutorRequest, ListarLivroAutorCommand>();
    }
}
