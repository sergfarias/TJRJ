using AutoMapper;
namespace Works.DeveloperEvaluation.WebApi.Features.LivrosAutores.DeletarLivroAutor;

/// <summary>
/// Profile for mapping DeleteProject feature requests to commands
/// </summary>
public class DeletarLivroAutorProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for DeleteProject feature
    /// </summary>
    public DeletarLivroAutorProfile()
    {
        CreateMap<int, Application.LivrosAutores.DeletarLivroAutor.DeletarLivroAutorCommand>()
            .ConstructUsing(id => new Application.LivrosAutores.DeletarLivroAutor.DeletarLivroAutorCommand(id, id));
    }
}
