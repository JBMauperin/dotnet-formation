using BoardgameCollectionSystem.Models;
using BoardgameCollectionSystem.Repository;

namespace BoardgameCollectionSystem.Services
{
    public class PlayersService
    {
        private readonly LudoManagerDbContext _context;

        public string Toto = "tata";

        public PlayersService(LudoManagerDbContext context)
        {
            _context = context;
        }

        public List<Player> GetAllPlayers()
        {
            return _context.Players.OrderBy(p => p.Name).ToList();
        }

        public List<Player> GetPlayersByIds(List<int> playerIds)
        {
            return _context.Players.Where(p => playerIds.Contains(p.Id)).ToList();
        }
    }
}
