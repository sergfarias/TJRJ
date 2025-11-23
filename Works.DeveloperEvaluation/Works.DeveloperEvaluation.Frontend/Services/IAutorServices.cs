using Microsoft.AspNetCore.Mvc;
using System.Collections;
using Works.DeveloperEvaluation.Frontend.Models;
using Works.DeveloperEvaluation.WebApi.Features.Assuntos.ListarAssunto;
using Works.DeveloperEvaluation.WebApi.Features.Autores.ListarAutor;

namespace Works.DeveloperEvaluation.Frontend.Services
{
    public interface IAutorServices
    {
        Task<IEnumerable> GetAllAsync();
        Task<ListarAutorResponse> GetByIdAsync(int id);
        Task<ListarAutorResponse> CreateAsync(Autor autor);
        Task UpdateAsync(int id, Autor autor);
        Task DeleteAsync(int id);
    }
}
