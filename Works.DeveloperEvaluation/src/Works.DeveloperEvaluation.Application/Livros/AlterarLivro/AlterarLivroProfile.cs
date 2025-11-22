using AutoMapper;
using Works.DeveloperEvaluation.Domain.Entities;

namespace Works.DeveloperEvaluation.Application.Livros.AlterarLivro;

public class AlterarLivroProfile : Profile
{
    public AlterarLivroProfile()
    {
        CreateMap<AlterarLivroCommand, Livro>();
        CreateMap<Livro, AlterarLivroResult>();
    }
}
