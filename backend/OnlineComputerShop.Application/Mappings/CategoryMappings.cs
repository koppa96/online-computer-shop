using AutoMapper;
using OnlineComputerShop.Application.Features.Admin.Categories;
using OnlineComputerShop.Application.Features.Common.Categories;
using OnlineComputerShop.Dal.Entities;
using System;

namespace OnlineComputerShop.Application.Mappings
{
    public class CategoryMappings : Profile
    {
        public CategoryMappings()
        {
            CreateMap<Category, CategoryListResponse>();
            CreateMap<Category, CategoryGetResponse>();
            CreateMap<PropertyType, CategoryGetResponse.PropertyTypeGetResponse>();
            CreateMap<CategorySocket, CategoryGetResponse.CategorySocketGetResponse>()
                .ForMember(dst => dst.SocketName, opt => opt.MapFrom(src => src.Socket.Name));

            CreateMap<CategoryEditCommand.PropertyTypeEditCommand, PropertyType>()
                .ForMember(dst => dst.Id, opt => opt.MapFrom(src => src.Id.HasValue ? src.Id : default));
        }
    }
}