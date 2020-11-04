using System;

namespace OnlineComputerShop.Application.Services.Interfaces
{
    public interface IIdentityService
    {
        public Guid GetUserId();
    }
}