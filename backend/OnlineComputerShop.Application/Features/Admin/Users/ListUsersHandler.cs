using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OnlineComputerShop.Dal;
using OnlineComputerShop.Dal.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OnlineComputerShop.Application.Features.Admin.Users
{
    public class UserListQuery : IRequest<IEnumerable<UserListResponse>>
    {

    }

    public class UserListResponse
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public bool IsAdmin { get; set; }

    }

    public class ListUsersHandler : IRequestHandler<UserListQuery, IEnumerable<UserListResponse>>
    {
        private readonly IMapper mapper;
        private readonly UserManager<User> userManager;

        public ListUsersHandler(IMapper mapper, UserManager<User> userManager)
        {
            this.mapper = mapper;
            this.userManager = userManager;
        }
        public async Task<IEnumerable<UserListResponse>> Handle(UserListQuery request, CancellationToken cancellationToken)
        {
            var users = await userManager.Users.ToListAsync();
            var admins = await userManager.GetUsersInRoleAsync("Admin");
            return users.Select(x => 
                new UserListResponse
                {
                    Id = x.Id,
                    UserName = x.UserName,
                    IsAdmin = admins.Any(a => a.Id == x.Id)
                }    
            ).ToList();
            
        }
    }
}
