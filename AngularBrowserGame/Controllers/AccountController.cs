using System;
using System.Collections.Generic;
using System.Linq;
using BrowserGame.Core.Dtos;
using BrowserGame.Core.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AngularBrowserGame.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly IAuthenticationService _authenticationService;

        public AccountController(IAccountService accountService, IAuthenticationService authenticationService)
        {
            _accountService = accountService;
            _authenticationService = authenticationService;
        }

        [HttpPost]
        [Route("register")]
        public void Register(AccountRequestDto dto)
        {
            _accountService.AddUser(dto);
        }

        [HttpGet]
        [Route("users")]
        public IEnumerable<AccountResponseDto> GetUsers()
        {
            return _accountService.GetAllUsers().ToList();

        }

        [HttpPost]
        [Route("login")]
        public int Login(AccountRequestDto dto)
        {
            var logInResponse = _authenticationService.LogIn(dto);

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
            var cookie = Request.Cookies["authentication"];
            if (cookie == null)
            {
                return false;
            }

            return _authenticationService.IsLoggedIn(cookie);
        }
    }
}