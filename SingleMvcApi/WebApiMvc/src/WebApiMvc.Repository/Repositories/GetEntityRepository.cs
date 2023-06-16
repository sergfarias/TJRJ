using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Linq.Expressions;
using WebApiMvc.Model.Interfaces.Repository;
using WebApiMvc.Repository.EFCore;

namespace WebApiMvc.Repository.Repositories;
public abstract class GetEntityRepository<TEntity, TType> : IGetEntityRepository<TEntity, TType>
                                                          where TEntity : class
{

    #region Properties

    private readonly WebApiMvcDbContext _webApiMvcDbContext;

    #endregion

    #region Constructor

    protected GetEntityRepository(
        WebApiMvcDbContext webApiMvcDbContext
        )
    {
        _webApiMvcDbContext = webApiMvcDbContext ?? throw new ArgumentNullException(nameof(webApiMvcDbContext));
    }

    #endregion

    #region Public Methods

    public Task<IEnumerable<TEntity>> Filter(
        Func<TEntity, bool> filter
        )
    =>
        Task.FromResult( _webApiMvcDbContext.Set<TEntity>()
                                 .AsNoTrackingWithIdentityResolution()
                                 .Where(filter)
                                 .AsEnumerable<TEntity>());


    public async Task<List<TEntity>> FilterAsync(
        Expression<Func<TEntity, bool>> predicate
        )
    =>
        await _webApiMvcDbContext.Set<TEntity>()
                                 .AsNoTrackingWithIdentityResolution()
                                 .Where(predicate)
                                 .ToListAsync()
                                 .ConfigureAwait(false);

    public async Task<IEnumerable<TEntity>> GetAllAsync()
    =>
        await _webApiMvcDbContext.Set<TEntity>()
                                 .AsNoTrackingWithIdentityResolution()
                                 .ToListAsync()
                                 .ConfigureAwait(false);


    public async Task<TEntity?> GetByIdAsync(
        TType id
        )
    =>
         await _webApiMvcDbContext.Set<TEntity>()
                                  .FindAsync(id)
                                  .ConfigureAwait(false);


    #endregion
}
