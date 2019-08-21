using Microsoft.EntityFrameworkCore.Design;

namespace BrowserGame.Database
{
    public class TemporaryDbContextFactory : IDesignTimeDbContextFactory<BrowserGameContext>
    {
        public BrowserGameContext CreateDbContext(string[] args)
        {
            return new BrowserGameContext();
        }
    }
}
