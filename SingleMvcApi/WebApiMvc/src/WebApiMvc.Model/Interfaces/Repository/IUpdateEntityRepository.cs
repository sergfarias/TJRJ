namespace WebApiMvc.Model.Interfaces.Repository;

public interface IUpdateEntityRepository<TEntity> where TEntity : class
{
    /// <summary>
    /// Update a entitie.
    /// </summary>
    /// <param name="entity">Entitie to update.</param>
    /// <returns>Entity updated.</returns>

    public void Update(TEntity entity);
}

