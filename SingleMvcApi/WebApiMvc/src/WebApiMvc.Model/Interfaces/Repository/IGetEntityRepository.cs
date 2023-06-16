using System.Linq.Expressions;

namespace WebApiMvc.Model.Interfaces.Repository;

public interface IGetEntityRepository<TEntity, TType> where TEntity : class
{
    public Task<TEntity> GetByIdAsync(TType id);
    public Task<IEnumerable<TEntity>> GetAllAsync();
    Task<List<TEntity>> FilterAsync(Expression<Func<TEntity, bool>> predicate);
    Task<IEnumerable<TEntity>> Filter(Func<TEntity, bool> filter);
}
