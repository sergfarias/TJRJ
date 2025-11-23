using Works.DeveloperEvaluation.Frontend.Models;
using Works.DeveloperEvaluation.WebApi.Features.Assuntos.ListarAssunto;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using Works.DeveloperEvaluation.WebApi.Features.Assuntos.BuscarAssunto;

namespace Works.DeveloperEvaluation.Frontend.Services
{
    public interface IAssuntoServices
    {
        Task<IEnumerable> GetAllAsync();
        Task<ListarAssuntoResponse> GetByIdAsync(int id);
        Task<ListarAssuntoResponse> CreateAsync(Assunto assunto);
        Task UpdateAsync(int id, Assunto assunto);
        Task DeleteAsync(int id);
    }
}
