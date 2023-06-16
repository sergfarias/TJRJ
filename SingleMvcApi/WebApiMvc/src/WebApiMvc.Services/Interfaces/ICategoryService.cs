using WebApiMvc.Model;

namespace WebApiMvc.Services.Interfaces;

public interface ICategoryService
{
    Task AddAsync(Category categoty);
    Task DeleteByIdAsync(Guid id);
    Task<IEnumerable<Category>> GetByAll();
    Task<IEnumerable<Category>> GetByFilterAsync(string filter);
    Task<Category?> GetByIdAsync(Guid id);
    Task UpdateAsync(Category categoty);
}