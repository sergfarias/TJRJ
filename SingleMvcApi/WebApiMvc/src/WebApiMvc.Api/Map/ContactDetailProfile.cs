using AutoMapper;
using WebApiMvc.Api.ViewModels;
using WebApiMvc.Model;

namespace WebApiMvc.Api.Map;

public class ContactDetailProfile : Profile
{
    public ContactDetailProfile()
    {
        CreateMap<ContactDetailViewModel, ContactDetail>();
        CreateMap<ContactDetail, ContactDetailViewModel>();
    }
}
