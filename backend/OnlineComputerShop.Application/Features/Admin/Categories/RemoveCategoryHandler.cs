﻿using MediatR;
using Microsoft.EntityFrameworkCore;
using OnlineComputerShop.Dal;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OnlineComputerShop.Application.Features.Admin.Categories
{
    public class CategoryRemoveCommand : IRequest
    {
        public Guid Id { get; set; }
    }

    public class RemoveCategoryHandler : IRequestHandler<CategoryRemoveCommand>
    {
        private readonly OnlineComputerShopContext context;

        public RemoveCategoryHandler(OnlineComputerShopContext context)
        {
            this.context = context;
        }
        public async Task<Unit> Handle(CategoryRemoveCommand request, CancellationToken cancellationToken)
        {
            var category = await context.Categories
                .Include(x => x.Products)
                .Include(x => x.PropertyTypes)
                .Include(x => x.CategorySockets)
                .SingleOrDefaultAsync(x => x.Id == request.Id);
            context.Categories.Remove(category);
            await context.SaveChangesAsync();
            return Unit.Value;
            
        }
    }
}
