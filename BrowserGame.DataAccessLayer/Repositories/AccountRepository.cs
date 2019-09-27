using System.Collections.Generic;
using System.Linq;
using BrowserGame.DataAccessLayer.Models;
using BrowserGame.DataAccessLayer.Repositories.Interfaces;
using BrowserGame.Database;
using BrowserGame.Database.Models;

namespace BrowserGame.DataAccessLayer.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly BrowserGameContext _context;

        public AccountRepository(BrowserGameContext context)
        {
            _context = context;
        }

        public IEnumerable<AccountModel> GetAll()
        {
            return _context.Accounts.Select(a => new AccountModel
            {
                Id = a.Id,
                Username = a.Username,
                Email = a.Email,
                PasswordHash = a.PasswordHash
            });
        }

        public void AddAccount(AccountModel model)
        {
            _context.Accounts.Add(new Account
            {
                Username = model.Username,
                Email = model.Username,
                PasswordHash = model.PasswordHash
            });
            _context.SaveChanges();
        }

        public AccountModel GetAccountByUsernameAndPassword(string username, byte[] passwordHash)
        {
            var account = _context.Accounts.FirstOrDefault(a => a.Username == username && a.PasswordHash == passwordHash);
            if (account == null)
            {
                return null;
            }

            return new AccountModel
            {
                Id = account.Id,
                Username = account.Username,
                Email = account.Email,
                PasswordHash = account.PasswordHash
            };
        }

        public AccountModel GetById(int id)
        {
            var account = _context.Accounts.FirstOrDefault(a => a.Id == id);
            if (account == null)
            {
                return null;
            }

            return new AccountModel
            {
                Id = account.Id,
                Username = account.Username,
                Email = account.Email,
                PasswordHash = account.PasswordHash
            };
        }
    }
}
