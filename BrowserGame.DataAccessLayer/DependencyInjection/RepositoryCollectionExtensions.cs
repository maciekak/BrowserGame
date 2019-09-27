using BrowserGame.DataAccessLayer.Repositories;
using BrowserGame.DataAccessLayer.Repositories.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace BrowserGame.DataAccessLayer.DependencyInjection
{
    public static class RepositoryCollectionExtensions
    {
        public static void AddRepositoryDependencies(this IServiceCollection services)
        {
            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<IPlanetRepository, PlanetRepository>();
        }
    }
}
