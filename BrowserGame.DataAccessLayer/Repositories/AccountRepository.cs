using System.Collections.Generic;
using System.Linq;
using BrowserGame.DataAccessLayer.Models;
using BrowserGame.Database;
using BrowserGame.Database.Models;

namespace BrowserGame.DataAccessLayer.Repositories
{
    public class AccountRepository
    {
        private readonly BrowserGameContext _context;

        public AccountRepository()
        {
            _context = new BrowserGameContext();
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
    }
}
