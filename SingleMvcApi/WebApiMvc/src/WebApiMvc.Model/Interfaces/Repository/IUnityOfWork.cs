namespace WebApiMvc.Model.Interfaces.Repository;

public interface IUnityOfWork
{
    void Commit();
    Task CommitAsync();
}
