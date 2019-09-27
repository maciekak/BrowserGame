using System.Collections.Generic;
using BrowserGame.Core.Dtos;

namespace BrowserGame.Core.Services.Interfaces
{
    public interface IPlanetService
    {
        IEnumerable<PlanetResponseDto> GetAll();
    }
}
