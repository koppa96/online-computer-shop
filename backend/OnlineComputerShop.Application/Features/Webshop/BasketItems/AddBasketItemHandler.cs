﻿using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OnlineComputerShop.Application.Services.Interfaces;
using OnlineComputerShop.Dal;
using OnlineComputerShop.Dal.Entities;
using OnlineComputerShop.Dal.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OnlineComputerShop.Application.Features.Webshop.BasketItems
{
    
    public class BasketItemAddCommand : IRequest
    {
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
    }


    public class AddBasketItemHandler : IRequestHandler<BasketItemAddCommand>
    {
        private readonly OnlineComputerShopContext context;
        private readonly IMapper mapper;
        private readonly IIdentityService identityService;

        public AddBasketItemHandler(OnlineComputerShopContext context, IMapper mapper, IIdentityService identityService)
        {
            this.context = context;
            this.mapper = mapper;
            this.identityService = identityService;
        }
        public async Task<Unit> Handle(BasketItemAddCommand request, CancellationToken cancellationToken)
        {
            var user = await context.Users
                .Include(x => x.BasketItems)
                .SingleOrDefaultAsync(x => x.Id == identityService.GetUserId(), cancellationToken);

            var product = await context.Products.FindAsync(request.ProductId);
            if (product == null)
            {
                throw new EntityNotFoundException("Product with requested ID is not found");
            }

            if (product.Quantity < request.Quantity)
            {
                throw new ValidationException("Requested quantity of product is more than available quantity in stock");
            }

            var existingBasketItem = user.BasketItems.SingleOrDefault(x => x.ProductId == request.ProductId);
            if (existingBasketItem == null)
            {
                user.BasketItems.Add(mapper.Map<BasketItem>(request));
            }
            else
            {
                existingBasketItem.Quantity += request.Quantity;
            }
            product.Quantity -= request.Quantity;

            await context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
