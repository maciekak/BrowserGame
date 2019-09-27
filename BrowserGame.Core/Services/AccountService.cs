using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using BrowserGame.Core.Dtos;
using BrowserGame.Core.Services.Interfaces;
using BrowserGame.DataAccessLayer.Models;
using BrowserGame.DataAccessLayer.Repositories.Interfaces;

namespace BrowserGame.Core.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;

        public AccountService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public void AddUser(AccountRequestDto dto)
        {
            var sha = SHA256.Create();
            var hash = sha.ComputeHash(Encoding.UTF8.GetBytes(dto.Password));
            var model = new AccountModel
            {
                Username = dto.Username,
                Email = dto.Username,
                PasswordHash = hash
            };
            _accountRepository.AddAccount(model);
        }

        public IEnumerable<AccountResponseDto> GetAllUsers()
        {
            return _accountRepository.GetAll()
                .Select(a => new AccountResponseDto
                {
                    Id = a.Id,
                    Username = a.Username,
                    Email = a.Email
                });
        }
    }
}
