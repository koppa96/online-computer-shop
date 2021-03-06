﻿using AutoMapper;
using OnlineComputerShop.Application.Features.Webshop.BasketItems;
using OnlineComputerShop.Dal.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineComputerShop.Application.Mappings
{
    public class BasketItemMappings : Profile
    {
        public BasketItemMappings()
        {
            CreateMap<BasketItem, BasketItemListResponse>()
                .ForMember(dst => dst.ProductName, opt => opt.MapFrom(src => src.Product.Name))
                .ForMember(dst => dst.PricePerPiece, opt => opt.MapFrom(src => src.Product.Price))
                .ForMember(dst => dst.CategoryId, opt => opt.MapFrom(src => src.Product.CategoryId))
                .ForMember(dst => dst.CategoryName, opt => opt.MapFrom(src => src.Product.Category.Name));
            CreateMap<BasketItem, BasketItemGetResponse>()
                .ForMember(dst => dst.ProductName, opt => opt.MapFrom(src => src.Product.Name))
                .ForMember(dst => dst.PricePerPiece, opt => opt.MapFrom(src => src.Product.Price));

            CreateMap<BasketItemAddCommand, BasketItem>();
            CreateMap<BasketItemEditCommand, BasketItem>();

        }
    }
}
