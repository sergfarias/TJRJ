using System.Linq.Expressions;
using WebApiMvc.Model.Interfaces.Repository;

namespace WebApiMvc.Model.Interfaces;

public interface IContactRepository : IBaseRepository<Contact, Guid>
{
    public new Task<Contact> GetByIdAsync(Guid id);
    public new Task<IEnumerable<Contact>> GetAllAsync();
    public new Task<List<Contact>> FilterAsync(Expression<Func<Contact, bool>> predicate);
    
}
