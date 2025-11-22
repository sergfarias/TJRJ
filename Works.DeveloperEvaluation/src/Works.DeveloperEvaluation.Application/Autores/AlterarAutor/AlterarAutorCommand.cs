using MediatR;
namespace Works.DeveloperEvaluation.Application.Autores.AlterarAutor;

public class AlterarAutorCommand : IRequest<AlterarAutorResult>
{
    public int CodAu { get; set; }
    public string Nome { get; set; } = string.Empty;
   
}