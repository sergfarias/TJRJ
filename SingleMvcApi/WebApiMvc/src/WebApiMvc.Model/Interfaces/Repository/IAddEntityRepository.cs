namespace WebApiMvc.Model.Interfaces.Repository;

public interface IAddEntityRepository<TEntity> where TEntity : class
{
    /// <summary>
    /// Add a new entitie.
    /// </summary>
    /// <param name="entity">Entitie to add.</param>
    /// <returns>Entity added.</returns>
    public Task AddAsync(TEntity entity);
}
