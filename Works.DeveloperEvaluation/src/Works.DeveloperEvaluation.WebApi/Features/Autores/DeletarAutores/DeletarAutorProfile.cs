using AutoMapper;
namespace Works.DeveloperEvaluation.WebApi.Features.Autores.DeletarAutor;

/// <summary>
/// Profile for mapping DeleteProject feature requests to commands
/// </summary>
public class DeletarAutorProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for DeleteProject feature
    /// </summary>
    public DeletarAutorProfile()
    {
        CreateMap<int, Application.Autores.DeletarAutor.DeletarAutorCommand>()
            .ConstructUsing(id => new Application.Autores.DeletarAutor.DeletarAutorCommand(id));
    }
}
