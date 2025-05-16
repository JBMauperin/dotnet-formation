using BoardgameCollectionSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace BoardgameCollectionSystem.Repository
{
    public class LudoManagerDbContext : DbContext
    {
        public LudoManagerDbContext(DbContextOptions<LudoManagerDbContext> options) : base(options)
        {
        }

        public DbSet<Player> Players { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<BoardGame> BoardGames { get; set; }
    }
}
