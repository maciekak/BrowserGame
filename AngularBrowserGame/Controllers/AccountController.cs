using System.Collections.Generic;
using System.Linq;
using BrowserGame.Core.Dtos;
using BrowserGame.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace AngularBrowserGame.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {

        [HttpPost]
        [Route("register")]
        public void Post(AccountRequestDto dto)
        {
            var service = new AccountService();
            service.AddUser(dto);
        }

        [HttpGet]
        [Route("users")]
        public IEnumerable<AccountResponseDto> Get()
        {
            var service = new AccountService();
            var a = service.GetAllUsers().ToList();
            return a;

        }
    }
}