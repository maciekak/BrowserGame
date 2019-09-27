using System.Collections.Generic;
using System.Linq;
using BrowserGame.Core.Dtos;
using BrowserGame.Core.Services.Interfaces;
using BrowserGame.DataAccessLayer.Repositories.Interfaces;

namespace BrowserGame.Core.Services
{
    public class PlanetService : IPlanetService
    {
        private readonly IPlanetRepository _planetRepository;

        public PlanetService(IPlanetRepository planetRepository)
        {
            _planetRepository = planetRepository;
        }

        public IEnumerable<PlanetResponseDto> GetAll()
        {
            return _planetRepository.GetAll().Select(p => new PlanetResponseDto
            {
                Id = p.Id,
                Size = p.Size
            });
        }
    }
}
