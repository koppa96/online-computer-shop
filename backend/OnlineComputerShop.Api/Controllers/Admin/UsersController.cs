using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineComputerShop.Application.Features.Admin.Users;

namespace OnlineComputerShop.Api.Controllers.Admin
{
    [ApiExplorerSettings(GroupName = "admin")]
    [Authorize("Admin")]
    [Route("api/admin/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator mediator;

        public UsersController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpGet]
        public Task<IEnumerable<UserListResponse>> ListUsers()
        {
            return mediator.Send(new UserListQuery());
        }
        
        [HttpPost("{userId}")]
        public Task CreateAdministrator(Guid userId)
        {
            return mediator.Send(new AdministratorCreateCommand { Id = userId });
        }

        [HttpDelete("{userId}")]
        public Task RemoveAdministrator(Guid userId)
        {
            return mediator.Send(new AdministratorRemoveCommand { Id = userId });
        }
    }
}