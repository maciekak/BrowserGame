using BrowserGame.Core.Services;
using BrowserGame.Core.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace BrowserGame.Core.DependencyInjection
{
    public static class ServicesCollectionExtensions
    {
        public static void AddServicesDependencies(this IServiceCollection services)
        {
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddScoped<IPlanetService, PlanetService>();
        }
    }
}
