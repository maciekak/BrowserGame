using System;
using System.Collections.Generic;
using System.Linq;
using BrowserGame.Core.Dtos;
using BrowserGame.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AngularBrowserGame.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {

        [HttpPost]
        [Route("register")]
        public void Register(AccountRequestDto dto)
        {
            var service = new AccountService();
            service.AddUser(dto);
        }

        [HttpGet]
        [Route("users")]
        public IEnumerable<AccountResponseDto> GetUsers()
        {
            var service = new AccountService();
            var a = service.GetAllUsers().ToList();
            return a;

        }

        [HttpPost]
        [Route("login")]
        public int Login(AccountRequestDto dto)
        {
            var service = new AuthenticationService();
            var logInResponse = service.LogIn(dto);

            if (logInResponse == null)
            {
                return -1;
            }

            var cookieOptions = new CookieOptions
            {
                Expires = DateTime.Now.AddMinutes(15)
            };

            Response.Cookies.Append("authentication", logInResponse.CookieContent, cookieOptions);

            return logInResponse.Id;
        }

        [HttpGet]
        [Route("logged")]
        public bool IsLogged()
        {
            var service = new AuthenticationService();
            var cookie = Request.Cookies["authentication"];
            if (cookie == null)
            {
                return false;
            }

            return service.IsLoggedIn(cookie);
        }
    }
}