using WebApiMvc.Model;

namespace WebApiMvc.Services.Interfaces;

public interface IContactService
{
    Task AddAsync(Contact contact);
    Task DeleteByIdAsync(Guid id);
    Task<IEnumerable<Contact>> GetByAll();
    Task<IEnumerable<Contact>> GetByNameAsync(string filter);
    Task<Contact> GetByIdAsync(Guid id);
    Task UpdateAsync(Contact contact);
    Task ActiveContactAsync(Guid id);
    Task InactiveContactAsync(Guid id);
    Task AddContactDetailAsync(Guid id, ContactDetail detail);
    Task ApplyCategoryAsync(Guid id, Guid idCategory);
    Task DeleteContactDetailAsync(Guid id, Guid idDetail);
}