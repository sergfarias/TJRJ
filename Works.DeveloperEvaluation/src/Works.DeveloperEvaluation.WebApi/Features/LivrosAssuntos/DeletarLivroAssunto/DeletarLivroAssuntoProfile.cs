using AutoMapper;
namespace Works.DeveloperEvaluation.WebApi.Features.LivrosAssuntos.DeletarLivroAssunto;

/// <summary>
/// Profile for mapping DeleteProject feature requests to commands
/// </summary>
public class DeletarLivroAssuntoProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for DeleteProject feature
    /// </summary>
    public DeletarLivroAssuntoProfile()
    {
        CreateMap<int, Application.LivrosAssuntos.DeletarLivroAssunto.DeletarLivroAssuntoCommand>()
            .ConstructUsing(id => new Application.LivrosAssuntos.DeletarLivroAssunto.DeletarLivroAssuntoCommand(id, id));
    }
}
