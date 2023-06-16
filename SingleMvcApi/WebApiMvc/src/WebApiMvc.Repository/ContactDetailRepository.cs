using WebApiMvc.Model;
using WebApiMvc.Model.Interfaces;
using WebApiMvc.Repository.EFCore;
using WebApiMvc.Repository.Repositories;

namespace WebApiMvc.Repository;

public class ContactDetailRepository : BaseRepository<ContactDetail, Guid>, IContactDetailRepository
{
    public ContactDetailRepository(WebApiMvcDbContext webApiMvcDbContext) : base(webApiMvcDbContext)
    {
    }
}
