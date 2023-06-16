using WebApiMvc.Model.Interfaces.Repository;
using WebApiMvc.Repository.EFCore;

namespace WebApiMvc.Repository.Repositories;

public abstract class UpdateEntityRepository<TEntity> : IUpdateEntityRepository<TEntity>
                                                        where TEntity : class
{
    #region Properties

    private readonly WebApiMvcDbContext _webApiMvcDbContext;

    #endregion

    #region Constructor

    protected UpdateEntityRepository(
        WebApiMvcDbContext webApiMvcDbContext
        )
    {
        _webApiMvcDbContext = webApiMvcDbContext ?? throw new ArgumentNullException(nameof(webApiMvcDbContext));
    }

    #endregion

    #region Public Methods

    public void Update(TEntity entity)

      =>
          _webApiMvcDbContext.Update<TEntity>(entity);

    #endregion

    #region Private Methods
    #endregion

}
