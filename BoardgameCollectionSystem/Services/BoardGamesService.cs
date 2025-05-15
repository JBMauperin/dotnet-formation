using BoardgameCollectionSystem.Models;
using BoardgameCollectionSystem.Repository;

namespace BoardgameCollectionSystem.Services
{
    public class BoardGamesService
    {
        private readonly LudoManagerDbContext _context;

        public BoardGamesService(LudoManagerDbContext context)
        {
            _context = context;
        }

        public List<BoardGame> GetAllBoardGames()
        {
            return _context.BoardGames.ToList();
        }

        public BoardGame GetBoardGameById(int id)
        {
            return _context.BoardGames.FirstOrDefault(bg => bg.Id == id);
        }
    }
}
