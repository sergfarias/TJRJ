using WebApiMvc.Model.Interfaces.Repository;

namespace WebApiMvc.Model.Interfaces;

public interface ICategoryRepository : IBaseRepository<Category, Guid>
{
}
