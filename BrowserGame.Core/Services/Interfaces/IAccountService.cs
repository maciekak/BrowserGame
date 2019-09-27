using System.Collections.Generic;
using BrowserGame.Core.Dtos;

namespace BrowserGame.Core.Services.Interfaces
{
    public interface IAccountService
    {
        void AddUser(AccountRequestDto dto);
        IEnumerable<AccountResponseDto> GetAllUsers();
    }
}
