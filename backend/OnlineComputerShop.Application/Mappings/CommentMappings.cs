using AutoMapper;
using OnlineComputerShop.Application.Features.Webshop.Comments;
using OnlineComputerShop.Application.Features.Webshop.Products;
using OnlineComputerShop.Application.Mappings.Resolvers;
using OnlineComputerShop.Dal.Entities;

namespace OnlineComputerShop.Application.Mappings
{
    public class CommentMappings : Profile
    {

        public CommentMappings()
        {
            CreateMap<CommentEditCommand, Comment>();
            CreateMap<CommentCreateCommand, Comment>()
                .ForMember(dst => dst.UserId, opt => opt.MapFrom<UserIdResolver>());
            
        }
    }
}
