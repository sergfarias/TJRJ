using AutoMapper;
using WebApiMvc.Api.ViewModels;
using WebApiMvc.Model;

namespace WebApiMvc.Api.Map;

public class ContactProfile : Profile
{
    public ContactProfile()
    {
        CreateMap<ContactViewModel, Contact>();
        CreateMap<Contact, ContactViewModel>();
    }
}
