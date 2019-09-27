using Microsoft.Extensions.DependencyInjection;

namespace BrowserGame.Database.DependencyInjection
{
    public static class ContextCollectionExtensions
    {
        public static void AddContextDependencies(this IServiceCollection services)
        {
            services.AddScoped<BrowserGameContext, BrowserGameContext>();
        }
    }
}
