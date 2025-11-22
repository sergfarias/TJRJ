using AutoMapper;
using Works.DeveloperEvaluation.Domain.Entities;
namespace Works.DeveloperEvaluation.Application.LivrosAssuntos.ListarLivroAssunto;

public class ListarLivroAssuntoProfile : Profile
{
    public ListarLivroAssuntoProfile()
    {
        CreateMap<ListarLivroAssuntoCommand, LivroAssunto>();
        CreateMap<LivroAssunto, ListarLivroAssuntoResult>();
    }
}
