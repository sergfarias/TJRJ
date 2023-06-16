using WebApiMvc.Model.Interfaces.Repository;
using WebApiMvc.Repository.EFCore;

namespace WebApiMvc.Repository.Repositories;

public abstract class DeleteEntityRepository<TEntity, TType> : IDeleteEntityRepository<TEntity, TType>
                                                             where TEntity : class
{
    #region Properties

    private readonly WebApiMvcDbContext _webApiMvcDbContext;

    #endregion

    #region Constructor

    protected DeleteEntityRepository(
        WebApiMvcDbContext webApiMvcDbContext
        )
    {
        _webApiMvcDbContext = webApiMvcDbContext ?? throw new ArgumentNullException(nameof(webApiMvcDbContext));
    }


    #endregion

    #region Public Methods

    public void Delete(
        TEntity entity
        )
    =>
        _webApiMvcDbContext.Remove<TEntity>(entity);
    

    public void DeleteById(
        TType id
        )
    {
        var objResult = _webApiMvcDbContext.Set<TEntity>()
                                           .Find(id);

        if (objResult is null)
            return;

        Delete(objResult);
    }

    #endregion

    #region Private Methods
    #endregion

}
