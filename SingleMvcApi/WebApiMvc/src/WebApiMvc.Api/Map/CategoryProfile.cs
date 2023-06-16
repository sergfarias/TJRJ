using AutoMapper;
using WebApiMvc.Api.ViewModels;
using WebApiMvc.Model;

namespace WebApiMvc.Api.Map;

public class CategoryProfile : Profile
{
    public CategoryProfile()
    {
        CreateMap<CategoryViewModel, Category>();
        CreateMap<Category, CategoryViewModel>();
    }
}
