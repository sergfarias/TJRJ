namespace WebApiMvc.Model.Interfaces.Repository;

public interface IBaseRepository<TEntity, TType> : IAddEntityRepository<TEntity>,
                                                   IUpdateEntityRepository<TEntity>,
                                                   IDeleteEntityRepository<TEntity, TType>,
                                                   IGetEntityRepository<TEntity, TType>,
                                                   IUnityOfWork
                 where TEntity : class
{
}
