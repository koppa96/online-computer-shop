using AutoMapper;
using OnlineComputerShop.Application.Features.Admin.Categories;
using OnlineComputerShop.Dal.Entities;

namespace OnlineComputerShop.Application.Mappings
{
    public class CategoryMappings : Profile
    {
        public CategoryMappings()
        {
            CreateMap<Category, CategoryListResponse>();
        }
    }
}