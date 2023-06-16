using WebApiMvc.Model;
using WebApiMvc.Model.Interfaces;
using WebApiMvc.Repository.EFCore;
using WebApiMvc.Repository.Repositories;

namespace WebApiMvc.Repository;

public class CategoryRepository : BaseRepository<Category, Guid>, ICategoryRepository
{
    public CategoryRepository(WebApiMvcDbContext webApiMvcDbContext) : base(webApiMvcDbContext)
    {
    }
}
