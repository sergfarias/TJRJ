using AutoMapper;
using Works.DeveloperEvaluation.Domain.Entities;
namespace Works.DeveloperEvaluation.Application.Assuntos.BuscarAssunto;

public class BuscarAssuntoProfile : Profile
{
    public BuscarAssuntoProfile()
    {
        CreateMap<BuscarAssuntoCommand, Assunto>();
        CreateMap<Assunto, BuscarAssuntoResult>();
    }
}
