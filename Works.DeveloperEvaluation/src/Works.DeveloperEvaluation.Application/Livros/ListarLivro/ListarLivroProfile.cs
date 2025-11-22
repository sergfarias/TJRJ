using AutoMapper;
using Works.DeveloperEvaluation.Domain.Entities;
namespace Works.DeveloperEvaluation.Application.Livros.ListarLivro;

public class ListarLivroProfile : Profile
{
    public ListarLivroProfile()
    {
        CreateMap<ListarLivroCommand, Livro>();
        CreateMap<Livro, ListarLivroResult>();
    }
}
