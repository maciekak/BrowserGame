using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using BrowserGame.Core.Dtos;
using BrowserGame.DataAccessLayer.Models;
using BrowserGame.DataAccessLayer.Repositories;

namespace BrowserGame.Core.Services
{
    public class AccountService
    {
        private readonly AccountRepository _accountRepository;

        public AccountService()
        {
            _accountRepository = new AccountRepository();
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
