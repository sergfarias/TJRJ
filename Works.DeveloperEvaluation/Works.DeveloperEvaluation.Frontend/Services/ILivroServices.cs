using Works.DeveloperEvaluation.Frontend.Models;
using Works.DeveloperEvaluation.WebApi.Features.Livros.ListarLivro;
using Microsoft.AspNetCore.Mvc;
using System.Collections;

namespace Works.DeveloperEvaluation.Frontend.Services
{
    public interface ILivroServices
    {
        Task<IEnumerable> GetAllAsync();
        Task<ListarLivroResponse> GetByIdAsync(int id);
        Task<ListarLivroResponse> CreateAsync(Livro livro);
        Task UpdateAsync(int id, Livro livro);
        Task DeleteAsync(int id);
        Task<IEnumerable> Relatorio();
    }
}
