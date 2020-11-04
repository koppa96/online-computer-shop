using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineComputerShop.Application.Features.Admin.Administrators;

namespace OnlineComputerShop.Api.Controllers.Admin
{
    [Authorize("Admin")]
    [Route("api/admin/[controller]")]
    [ApiController]
    public class AdministratorsController : ControllerBase
    {
        private readonly IMediator mediator;

        public AdministratorsController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpGet]
        public Task<IEnumerable<AdministratorListResponse>> ListAdministrators()
        {
            throw new NotImplementedException();
        }
        
        [HttpPost]
        public Task CreateAdministrator()
        {
            throw new NotImplementedException();
        }

        [HttpDelete("{administratorId}")]
        public Task RemoveAdministrator(Guid administratorId)
        {
            throw new NotImplementedException();
        }
    }
}