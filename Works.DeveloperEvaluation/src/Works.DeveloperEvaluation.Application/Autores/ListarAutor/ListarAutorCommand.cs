using MediatR;
namespace Works.DeveloperEvaluation.Application.Autores.ListarAutor;

/// <summary>
/// Command for list a project.
/// </summary>
public class ListarAutorCommand : IRequest<List<ListarAutorResult>>
{
    public int CodAu { get; set; }

}