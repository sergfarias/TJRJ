using MediatR;
namespace Works.DeveloperEvaluation.Application.Autores.BuscarAutor;

/// <summary>
/// Command for list a project.
/// </summary>
public class BuscarAutorCommand : IRequest<BuscarAutorResult>
{
    public int CodAu { get; set; }

}