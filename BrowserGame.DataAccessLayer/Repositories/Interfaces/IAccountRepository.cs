using System.Collections.Generic;
using BrowserGame.DataAccessLayer.Models;

namespace BrowserGame.DataAccessLayer.Repositories.Interfaces
{
    public interface IAccountRepository
    {
        IEnumerable<AccountModel> GetAll();
        void AddAccount(AccountModel model);
        AccountModel GetAccountByUsernameAndPassword(string username, byte[] passwordHash);
        AccountModel GetById(int id);
    }
}
