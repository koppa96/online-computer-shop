using AutoMapper;
using OnlineComputerShop.Application.Features.Admin.Sockets;
using OnlineComputerShop.Dal.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineComputerShop.Application.Mappings
{
    public class SocketMappings : Profile
    {
        public SocketMappings() 
        {
            CreateMap<Socket, SocketListResponse>();
            CreateMap<Socket, SocketGetResponse>();
            CreateMap<CategorySocket, SocketGetResponse.CategorySocketGetResponse>()
                .ForMember(dst => dst.CategoryName, opt => opt.MapFrom(src => src.Category.Name));
            CreateMap<SocketCreateCommand, Socket>();
        }
    }
}
