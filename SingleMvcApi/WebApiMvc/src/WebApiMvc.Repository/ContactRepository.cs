using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WebApiMvc.Model;
using WebApiMvc.Model.Interfaces;
using WebApiMvc.Repository.EFCore;
using WebApiMvc.Repository.Repositories;

namespace WebApiMvc.Repository;

public class ContactRepository : BaseRepository<Contact, Guid>, IContactRepository
{
    private readonly WebApiMvcDbContext _webApiMvcDbContext;
    public ContactRepository(WebApiMvcDbContext webApiMvcDbContext) : base(webApiMvcDbContext)
    {
        _webApiMvcDbContext = webApiMvcDbContext;
    }

    public new async Task<List<Contact>> FilterAsync(
        Expression<Func<Contact, bool>> predicate
        )
    =>
        await _webApiMvcDbContext.Set<Contact>()
                                 .Include(p => p.Category) 
                                 .Include(p => p.ContactsDetails) 
                                 .AsNoTrackingWithIdentityResolution()
                                 .Where(predicate)
                                 .ToListAsync()
                                 .ConfigureAwait(false);

    public new async Task<IEnumerable<Contact>> GetAllAsync()
    =>
        await _webApiMvcDbContext.Set<Contact>()
                                 .Include(p => p.Category)
                                 .Include(p => p.ContactsDetails)
                                 .AsNoTrackingWithIdentityResolution()
                                 .ToListAsync()
                                 .ConfigureAwait(false);

    public new async Task<Contact> GetByIdAsync(
        Guid id
        )
    =>
         await _webApiMvcDbContext.Set<Contact>()
                                  .Include(p => p.Category)
                                  .Include(p => p.ContactsDetails)
                                  .AsNoTrackingWithIdentityResolution()
                                  .FirstOrDefaultAsync(p => p.Id == id)
                                  .ConfigureAwait(false);


}
