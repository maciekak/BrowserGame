using System.Collections.Generic;
using BrowserGame.DataAccessLayer.Models;

namespace BrowserGame.DataAccessLayer.Repositories.Interfaces
{
    public interface IPlanetRepository
    {
        IEnumerable<PlanetModel> GetAll();
    }
}
