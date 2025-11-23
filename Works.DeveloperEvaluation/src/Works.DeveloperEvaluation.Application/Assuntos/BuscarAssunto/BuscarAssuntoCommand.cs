using MediatR;
namespace Works.DeveloperEvaluation.Application.Assuntos.BuscarAssunto;

/// <summary>
/// Command for list a project.
/// </summary>
public class BuscarAssuntoCommand : IRequest<BuscarAssuntoResult>
{
    public int CodAs { get; set; }

}