using AutoMapper;
using WebApiMvc.Api.ViewModels;
using WebApiMvc.Model.ObjectValue;

namespace WebApiMvc.Api.Map;

public class AddressDetailProfile : Profile
{
    public AddressDetailProfile()
    {
        CreateMap<AddressDetailViewModel, AddressDetail>();
        CreateMap<AddressDetail, AddressDetailViewModel>();
    }
}
