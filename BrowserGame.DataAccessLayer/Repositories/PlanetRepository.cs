using System.Collections.Generic;
using System.Linq;
using BrowserGame.DataAccessLayer.Models;
using BrowserGame.Database;

namespace BrowserGame.DataAccessLayer.Repositories
{
    public class PlanetRepository
    {
        public IEnumerable<PlanetModel> GetAll()
        {
            var context = new BrowserGameContext();
            return context.Planets.Select(p => new PlanetModel
            {
                Id = p.Id,
                Size = p.Size
            });
        }
    }
}
