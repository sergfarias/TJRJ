using MediatR;
namespace Works.DeveloperEvaluation.Application.Assuntos.ListarAssunto;

/// <summary>
/// Command for list a project.
/// </summary>
public class ListarAssuntoCommand : IRequest<List<ListarAssuntoResult>>
{
    public int CodAs { get; set; }

}