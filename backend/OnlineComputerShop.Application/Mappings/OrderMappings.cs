using AutoMapper;
using OnlineComputerShop.Application.Features.Admin.Orders;
using OnlineComputerShop.Application.Features.Common.Orders;
using OnlineComputerShop.Application.Features.Webshop.Orders;
using OnlineComputerShop.Dal.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineComputerShop.Application.Mappings
{
    public class OrderMappings : Profile
    {
        public OrderMappings()
        {
            CreateMap<Order, OrderGetResponse>()
                .ForMember(dst => dst.UserName, opt => opt.MapFrom(src => src.User.UserName));
            CreateMap<OrderItem, OrderGetResponse.OrderItemGetResponse>()
                .ForMember(dst => dst.ProductName, opt => opt.MapFrom(src => src.Product.Name))
                .ForMember(dst => dst.CategoryId, opt => opt.MapFrom(src => src.Product.CategoryId));
            CreateMap<Order, Features.Admin.Orders.OrderListResponse>()
                .ForMember(dst => dst.UserName, opt => opt.MapFrom(src => src.User.UserName));
            CreateMap<Order, Features.Webshop.Orders.OrderListResponse>();
        }
    }
}
