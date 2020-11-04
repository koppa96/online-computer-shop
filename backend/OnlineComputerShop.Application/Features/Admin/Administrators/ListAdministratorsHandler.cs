using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OnlineComputerShop.Dal;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OnlineComputerShop.Application.Features.Admin.Administrators
{
    public class AdministratorListQuery : IRequest<IEnumerable<AdministratorListResponse>>
    {

    }

    public class AdministratorListResponse
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }

    }

    public class ListAdministratorsHandler : IRequestHandler<AdministratorListQuery, IEnumerable<AdministratorListResponse>>
    {
        private readonly OnlineComputerShopContext context;
        private readonly IMapper mapper;

        public ListAdministratorsHandler(OnlineComputerShopContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public Task<IEnumerable<AdministratorListResponse>> Handle(AdministratorListQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
