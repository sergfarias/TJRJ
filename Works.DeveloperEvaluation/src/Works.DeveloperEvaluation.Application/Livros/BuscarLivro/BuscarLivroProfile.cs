using AutoMapper;
using Works.DeveloperEvaluation.Domain.Entities;
namespace Works.DeveloperEvaluation.Application.Livros.BuscarLivro;

public class BuscarLivroProfile : Profile
{
    public BuscarLivroProfile()
    {
        CreateMap<BuscarLivroCommand, Livro>();
        CreateMap<Livro, BuscarLivroResult>();
    }
}
