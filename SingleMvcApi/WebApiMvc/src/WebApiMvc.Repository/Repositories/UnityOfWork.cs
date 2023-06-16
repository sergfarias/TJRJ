using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiMvc.Model.Interfaces.Repository;
using WebApiMvc.Repository.EFCore;

namespace WebApiMvc.Repository.Repositories;

public abstract class UnityOfWork : IUnityOfWork
{
    #region Properties

    private readonly WebApiMvcDbContext _webApiMvcDbContext;

    #endregion

    #region Constructor

    protected UnityOfWork(
        WebApiMvcDbContext webApiMvcDbContext
        )
    {
        _webApiMvcDbContext = webApiMvcDbContext ?? throw new ArgumentNullException(nameof(webApiMvcDbContext));
    }


    public void Commit()
    =>
        _webApiMvcDbContext.SaveChanges();

    #endregion

    #region Public Methods

    public async Task CommitAsync()
    =>
        await _webApiMvcDbContext.SaveChangesAsync();


    #endregion
}
