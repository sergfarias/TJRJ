using AutoMapper;
namespace Works.DeveloperEvaluation.WebApi.Features.Assuntos.DeletarAssunto;

/// <summary>
/// Profile for mapping DeleteProject feature requests to commands
/// </summary>
public class DeletarAssuntoProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for DeleteProject feature
    /// </summary>
    public DeletarAssuntoProfile()
    {
        CreateMap<int, Application.Assuntos.DeletarAssunto.DeletarAssuntoCommand>()
            .ConstructUsing(id => new Application.Assuntos.DeletarAssunto.DeletarAssuntoCommand(id));
    }
}
