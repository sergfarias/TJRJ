using AutoMapper;
using Works.DeveloperEvaluation.Domain.Entities;
namespace Works.DeveloperEvaluation.Application.Autores.ListarAutor;

public class ListarAutorProfile : Profile
{
    public ListarAutorProfile()
    {
        CreateMap<ListarAutorCommand, Autor>();
        CreateMap<Autor, ListarAutorResult>();
    }
}
