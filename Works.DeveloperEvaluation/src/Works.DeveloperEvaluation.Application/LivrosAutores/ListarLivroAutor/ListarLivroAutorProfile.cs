using AutoMapper;
using Works.DeveloperEvaluation.Domain.Entities;
namespace Works.DeveloperEvaluation.Application.LivrosAutores.ListarLivroAutor;

public class ListarLivroAutorProfile : Profile
{
    public ListarLivroAutorProfile()
    {
        CreateMap<ListarLivroAutorCommand, LivroAutor>();
        CreateMap<LivroAutor, ListarLivroAutorResult>();
    }
}
