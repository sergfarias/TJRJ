namespace WebApiMvc.Model.Interfaces.Repository;

public interface IDeleteEntityRepository<TEntity, TType> where TEntity : class
{
    /// <summary>
    /// Delete a entitie.
    /// </summary>
    /// <param name="entity">Entitie to delete.</param>
    /// <returns></returns>

    public void Delete(TEntity entity);

    /// <summary>
    /// Delete a entitie by id.
    /// </summary>
    /// <param name="id">Entitie Id to delete.</param>
    /// <returns></returns>

    public void DeleteById(TType id);
}
