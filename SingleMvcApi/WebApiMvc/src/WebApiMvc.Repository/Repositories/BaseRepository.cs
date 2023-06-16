using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WebApiMvc.Model.Interfaces.Repository;
using WebApiMvc.Repository.EFCore;

namespace WebApiMvc.Repository.Repositories;

public abstract class BaseRepository<TEntity, TType> : IBaseRepository<TEntity, TType>,
                                                       IDisposable where TEntity : class
{
    #region Properties

    private readonly WebApiMvcDbContext _webApiMvcDbContext;

    #endregion

    #region Constructor

    protected BaseRepository(
        WebApiMvcDbContext webApiMvcDbContext
        )
    {
        _webApiMvcDbContext = webApiMvcDbContext ?? throw new ArgumentNullException(nameof(webApiMvcDbContext));
    }

    #endregion

    #region Write Operations

    public async Task AddAsync(
        TEntity entity
        )
    =>
        await _webApiMvcDbContext.AddAsync<TEntity>(entity)
                                 .ConfigureAwait(false);


    public void Update(
        TEntity entity
        )
      =>
          _webApiMvcDbContext.Update<TEntity>(entity);


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

    public void Commit()
    =>
        _webApiMvcDbContext.SaveChanges();

    public async Task CommitAsync()
    =>
        await _webApiMvcDbContext.SaveChangesAsync();


    #endregion

    #region Read Operations

    public Task<IEnumerable<TEntity>> Filter(
        Func<TEntity, bool> filter
        )
     =>
        Task.FromResult(_webApiMvcDbContext.Set<TEntity>()
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


    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (disposing)
        {
            _webApiMvcDbContext.Dispose();
        }
    }

}
