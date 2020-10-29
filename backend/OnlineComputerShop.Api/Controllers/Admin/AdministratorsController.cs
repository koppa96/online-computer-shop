using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace OnlineComputerShop.Api.Controllers.Admin
{
    [Authorize("Admin")]
    [Route("api/admin/[controller]")]
    [ApiController]
    public class AdministratorsController : ControllerBase
    {
        [HttpGet]
        public Task ListAdministrators()
        {
            throw new NotImplementedException();
        }
        
        [HttpPost]
        public Task CreateAdministrator()
        {
            throw new NotImplementedException();
        }

        [HttpDelete("{id}")]
        public Task DeleteAdministrator(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}