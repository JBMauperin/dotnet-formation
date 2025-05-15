using BoardgameCollectionSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace BoardgameCollectionSystem.Repository
{
    public class LudoManagerDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=LudoManager;User Id=sa;Password=@M@r!s2024;TrustServerCertificate=True;");
            //optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=LudoManager;TrustServerCertificate=True;Trusted_Connection=True;");
        }

        public DbSet<Player> Players { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<BoardGame> BoardGames { get; set; }
    }
}
