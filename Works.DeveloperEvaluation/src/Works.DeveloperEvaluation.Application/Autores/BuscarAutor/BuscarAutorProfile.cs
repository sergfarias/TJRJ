using AutoMapper;
using Works.DeveloperEvaluation.Domain.Entities;
namespace Works.DeveloperEvaluation.Application.Autores.BuscarAutor;

public class BuscarAutorProfile : Profile
{
    public BuscarAutorProfile()
    {
        CreateMap<BuscarAutorCommand, Autor>();
        CreateMap<Autor, BuscarAutorResult>();
    }
}
