using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OnlineComputerShop.Dal;

namespace OnlineComputerShop.Application.Features.Common.Categories
{
    public class CategoryListQuery : IRequest<IEnumerable<CategoryListResponse>>
    {
    }

    public class CategoryListResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
    
    public class ListCategoriesHandler : IRequestHandler<CategoryListQuery, IEnumerable<CategoryListResponse>>
    {
        private readonly OnlineComputerShopContext context;
        private readonly IMapper mapper;

        public ListCategoriesHandler(OnlineComputerShopContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        
        public async Task<IEnumerable<CategoryListResponse>> Handle(CategoryListQuery request, CancellationToken cancellationToken)
        {
            var categories = await context.Categories.ToListAsync(cancellationToken);
            
            // Ezek ekvivalensek
            // return categories.Select(mapper.Map<CategoryListResponse>);
            // return categories.Select(x => mapper.Map<CategoryListResponse>(x));
            return mapper.Map<List<CategoryListResponse>>(categories);
        }
    }
}