using AutoMapper;
using Works.DeveloperEvaluation.Domain.Entities;
namespace Works.DeveloperEvaluation.Application.Assuntos.ListarAssunto;

public class ListarAssuntoProfile : Profile
{
    public ListarAssuntoProfile()
    {
        CreateMap<ListarAssuntoCommand, Assunto>();
        CreateMap<Assunto, ListarAssuntoResult>();
    }
}
