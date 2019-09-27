using BrowserGame.Core.Dtos;

namespace BrowserGame.Core.Services.Interfaces
{
    public interface IAuthenticationService
    {
        LogInResponseDto LogIn(AccountRequestDto dto);
        bool IsLoggedIn(string cookieContent);
    }
}
