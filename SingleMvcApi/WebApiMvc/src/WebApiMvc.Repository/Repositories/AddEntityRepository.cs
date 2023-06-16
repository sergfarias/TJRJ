using WebApiMvc.Model.Interfaces.Repository;
using WebApiMvc.Repository.EFCore;

namespace WebApiMvc.Repository.Repositories;

public abstract class AddEntityRepository<TEntity> : IAddEntityRepository<TEntity>
                                                   where TEntity : class
{
    #region Properties

    private readonly WebApiMvcDbContext _webApiMvcDbContext;

    #endregion

    #region Constructor

    protected AddEntityRepository(
        WebApiMvcDbContext webApiMvcDbContext
        )
    {
        _webApiMvcDbContext = webApiMvcDbContext ?? throw new ArgumentNullException(nameof(webApiMvcDbContext));
    }

    #endregion

    #region Public Methods

    public async Task AddAsync(
        TEntity entity
        )
      =>
         await _webApiMvcDbContext.AddAsync<TEntity>(entity)
                                  .ConfigureAwait(false);


    #endregion

    #region Private Methods
    #endregion
}
