using MediatR;
namespace Works.DeveloperEvaluation.Application.Assuntos.AlterarAssunto;

public class AlterarAssuntoCommand : IRequest<AlterarAssuntoResult>
{
    public int CodAs { get; set; }
    public string Descricao { get; set; } = string.Empty;
   
}