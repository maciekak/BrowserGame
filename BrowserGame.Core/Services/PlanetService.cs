using System.Collections.Generic;
using System.Linq;
using BrowserGame.Core.Dtos;
using BrowserGame.DataAccessLayer.Repositories;

namespace BrowserGame.Core.Services
{
    public class PlanetService
    {
        public IEnumerable<PlanetDto> GetAll()
        {
            var repository = new PlanetRepository();
            return repository.GetAll().Select(p => new PlanetDto
            {
                Id = p.Id,
                Size = p.Size
            });
        }
    }
}
