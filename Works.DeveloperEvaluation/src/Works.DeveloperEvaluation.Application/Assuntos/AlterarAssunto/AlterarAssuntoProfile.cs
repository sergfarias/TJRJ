using AutoMapper;
using Works.DeveloperEvaluation.Domain.Entities;

namespace Works.DeveloperEvaluation.Application.Assuntos.AlterarAssunto;

public class AlterarAssuntoProfile : Profile
{
    public AlterarAssuntoProfile()
    {
        CreateMap<AlterarAssuntoCommand, Assunto>();
        CreateMap<Assunto, AlterarAssuntoResult>();
    }
}
