using System.Security.Cryptography;
using System.Text;
using BrowserGame.Core.Dtos;
using BrowserGame.Core.Services.Interfaces;
using BrowserGame.DataAccessLayer.Repositories;
using BrowserGame.DataAccessLayer.Repositories.Interfaces;

namespace BrowserGame.Core.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private const string Secret = "123456789";

        private readonly IAccountRepository _accountRepository;

        public AuthenticationService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        private static string Sha256Hash(string value)
        {
            var builder = new StringBuilder();

            using (var hash = SHA256.Create())
            {
                var enc = Encoding.UTF8;
                var result = hash.ComputeHash(enc.GetBytes(value));

                foreach (var b in result)
                {
                    builder.Append(b.ToString("x2"));
                }
            }

            return builder.ToString();
        }

        public LogInResponseDto LogIn(AccountRequestDto dto)
        {
            var sha = SHA256.Create();
            var passwordHash = sha.ComputeHash(Encoding.UTF8.GetBytes(dto.Password));
            var account = _accountRepository.GetAccountByUsernameAndPassword(dto.Username, passwordHash);

            if (account == null)
            {
                return null;
            }

            var token = account.Id + ":" + account.Email + ":" + Secret;
            var hashedToken = Sha256Hash(token);
            var cookieContent = account.Id + ":" + hashedToken;

            return new LogInResponseDto
            {
                Id = account.Id,
                CookieContent = cookieContent
            };
        }

        public bool IsLoggedIn(string cookieContent)
        {
            var splitted = cookieContent.Split(':');
            if (splitted.Length != 2)
            {
                return false;
            }

            if (int.TryParse(splitted[0], out var id) == false)
            {
                return false;
            }

            var cookieHash = splitted[1];

            var account = _accountRepository.GetById(id);
            var token = account.Id + ":" + account.Email + ":" + Secret;
            var hashedToken = Sha256Hash(token);
            return hashedToken == cookieHash;
        }
    }
}
