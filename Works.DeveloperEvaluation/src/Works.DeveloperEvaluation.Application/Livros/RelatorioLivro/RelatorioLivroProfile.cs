using AutoMapper;
using Works.DeveloperEvaluation.Application.Livros.ListarLivro;
using Works.DeveloperEvaluation.Domain.Entities;
namespace Works.DeveloperEvaluation.Application.Livros.RelatorioLivro;

public class RelatorioLivroProfile : Profile
{
    public RelatorioLivroProfile()
    {
        CreateMap<RelatorioLivroCommand, LivroDetalhesView>();
        CreateMap<LivroDetalhesView, RelatorioLivroResult>();
    }
}
