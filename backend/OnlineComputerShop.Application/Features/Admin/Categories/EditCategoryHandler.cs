using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OnlineComputerShop.Dal;
using OnlineComputerShop.Dal.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OnlineComputerShop.Dal.Exceptions;

namespace OnlineComputerShop.Application.Features.Admin.Categories
{
    public class CategoryEditCommand : IRequest
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public List<PropertyTypeEditCommand> PropertyTypes { get; set; }
        public List<CategorySocketEditCommand> CategorySockets { get; set; }

        public class PropertyTypeEditCommand
        {
            public Guid? Id { get; set; }
            public string Name { get; set; }
        }

        public class CategorySocketEditCommand
        {
            public Guid SocketId { get; set; }
        }
    }


    public class EditCategoryHandler : IRequestHandler<CategoryEditCommand>
    {
        private readonly OnlineComputerShopContext context;
        private readonly IMapper mapper;

        public EditCategoryHandler(OnlineComputerShopContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public async Task<Unit> Handle(CategoryEditCommand request, CancellationToken cancellationToken)
        {
            var category = await context.Categories
                .Include(x => x.PropertyTypes)
                .Include(x => x.CategorySockets)
                .SingleOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
            
            if (category == null)
                throw new EntityNotFoundException("No category with the given id was found.");
            
            category.Name = request.Name;

            // Property types
            // Remove property types to be removed
            context.PropertyTypes.RemoveRange(
                category.PropertyTypes.Where(x => request.PropertyTypes.All(pt => pt.Id != x.Id)));
            
            // Update existing property types
            foreach (var propertyType in category.PropertyTypes)
            {
                propertyType.Name = request.PropertyTypes.SingleOrDefault(x => x.Id == propertyType.Id)?.Name;
            }
            
            // Add property types to be added
            context.PropertyTypes.AddRange(
                request.PropertyTypes.Where(x => category.PropertyTypes.All(pt => pt.Id != x.Id))
                    .Select(x => new PropertyType
                    {
                        CategoryId = category.Id,
                        Name = x.Name
                    }));

            // Category Sockets
            context.CategorySockets.RemoveRange(category.CategorySockets);
            context.CategorySockets.AddRange(request.CategorySockets.Select(x => new CategorySocket
            {
                CategoryId = category.Id,
                SocketId = x.SocketId
            }));
            
            await context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
