using AutoMapper;
using OnlineComputerShop.Application.Features.Admin.Products;
using OnlineComputerShop.Application.Features.Common.Products;
using OnlineComputerShop.Dal.Entities;
using System.Linq;

namespace OnlineComputerShop.Application.Mappings
{
    public class ProductMappings : Profile
    {
        public ProductMappings()
        {
            CreateMap<Product, ProductGetResponse>()
                .ForMember(dst => dst.Category, opt => opt.MapFrom(src => src.Category.Name))
                .ForMember(dst => dst.Comments, opt => opt.MapFrom(src => src.Comments.OrderByDescending(x => x.DateTimeOfCreation)));
            CreateMap<Comment, ProductGetResponse.CommentResponse>()
                .ForMember(dst => dst.UserName, opt => opt.MapFrom(src => src.User.UserName));

            CreateMap<Product, ProductListResponse>();
            CreateMap<ProductCreateCommand, Product>();
            CreateMap<PropertyValue, ProductGetResponse.PropertyValueResponse>()
                .ForMember(dst => dst.Name, opt => opt.MapFrom(src => src.PropertyType.Name))
                .ForMember(dst => dst.PropertyTypeId, opt => opt.MapFrom(src => src.PropertyTypeId));
            CreateMap<ProductSocket, ProductGetResponse.ProductSocketResponse>()
                .ForMember(dst => dst.Name, opt => opt.MapFrom(src => src.Socket.Name));
            CreateMap<ProductCreateCommand.PropertyValueCreateCommand, PropertyValue>();
            CreateMap<ProductCreateCommand.ProductSocketCreateCommand, ProductSocket>();
            CreateMap<ProductEditCommand, Product>();
            CreateMap<ProductEditCommand.ProductSocketEditCommand, ProductSocket>();
            CreateMap<ProductEditCommand.PropertyValueEditCommand, PropertyValue>();
        }
    }
}
