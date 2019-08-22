using BrowserGame.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace BrowserGame.Database
{
    public class BrowserGameContext : DbContext
    {
        public DbSet<Planet> Planets { get; set; }
        public DbSet<Account> Accounts { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=browser-game.db");
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Planet>().HasData(new Planet
            {
                Id = 1,
                Size = 13
            });
        }
    }
}
