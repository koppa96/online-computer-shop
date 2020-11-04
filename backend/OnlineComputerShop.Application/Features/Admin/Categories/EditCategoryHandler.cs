using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OnlineComputerShop.Dal;
using OnlineComputerShop.Dal.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

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
                .SingleOrDefaultAsync(x => x.Id == request.Id);
            if (category == null)
                throw new Exception();
            category.Name = request.Name;
            category.PropertyTypes = mapper.Map<List<PropertyType>>(request.PropertyTypes);
            category.CategorySockets = mapper.Map<List<CategorySocket>>(request.CategorySockets);
            return Unit.Value;
        }
    }
}
