using AutoMapper;
using MediatR;
using OnlineComputerShop.Dal;
using OnlineComputerShop.Dal.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OnlineComputerShop.Application.Features.Admin.Categories
{
    public class CategoryCreateCommand : IRequest
    {
        public string Name { get; set; }
        public List<string> PropertyTypes { get; set; }
        public List<Guid> SocketIds { get; set; }
    }

    public class CreateCategoryHandler : IRequestHandler<CategoryCreateCommand>
    {
        private readonly OnlineComputerShopContext context;
        private readonly IMapper mapper;

        public CreateCategoryHandler(OnlineComputerShopContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public async Task<Unit> Handle(CategoryCreateCommand request, CancellationToken cancellationToken)
        {
            context.Categories.Add(new Category
            {
                Name = request.Name,
                PropertyTypes = request.PropertyTypes.Select(x => new PropertyType
                {
                    Name = x
                }).ToList(),
                CategorySockets = request.SocketIds.Select(x => new CategorySocket
                {
                    SocketId = x
                }).ToList()
            });
            
            await context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
