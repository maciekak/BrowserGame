using System.Collections.Generic;
using System.Linq;
using BrowserGame.DataAccessLayer.Models;
using BrowserGame.DataAccessLayer.Repositories.Interfaces;
using BrowserGame.Database;

namespace BrowserGame.DataAccessLayer.Repositories
{
    public class PlanetRepository : IPlanetRepository
    {
        private readonly BrowserGameContext _context;

        public PlanetRepository(BrowserGameContext context)
        {
            _context = context;
        }

        public IEnumerable<PlanetModel> GetAll()
        {
            return _context.Planets.Select(p => new PlanetModel
            {
                Id = p.Id,
                Size = p.Size
            });
        }
    }
}
