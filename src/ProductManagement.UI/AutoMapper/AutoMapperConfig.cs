using AutoMapper;
using ProductManagement.Domain.Entities;
using ProductManagement.UI.ViewModels;

namespace ProductManagement.UI.AutoMapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Product, ProductViewModel>().ReverseMap();
            CreateMap<Category, CategoryViewModel>().ReverseMap();
        }
    }
}