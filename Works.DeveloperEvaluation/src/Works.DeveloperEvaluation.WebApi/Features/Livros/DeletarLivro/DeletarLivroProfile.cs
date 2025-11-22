using AutoMapper;
namespace Works.DeveloperEvaluation.WebApi.Features.Livros.DeletarLivros;

/// <summary>
/// Profile for mapping DeleteProject feature requests to commands
/// </summary>
public class DeletarLivroProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for DeleteProject feature
    /// </summary>
    public DeletarLivroProfile()
    {
        CreateMap<int, Application.Livros.DeletarLivro.DeletarLivroCommand>()
            .ConstructUsing(id => new Application.Livros.DeletarLivro.DeletarLivroCommand(id));
    }
}
