using BoardgameCollectionSystem.Models;
using BoardgameCollectionSystem.Repository;

namespace BoardgameCollectionSystem.Services
{
    public class GamesService
    {
        private readonly LudoManagerDbContext _context;
        private readonly PlayersService _playersService;
        private readonly BoardGamesService _boardGamesService;

        public GamesService(LudoManagerDbContext context)
        {
            _context = context;
            _playersService = new PlayersService(_context);
            _boardGamesService = new BoardGamesService(_context);
        }

        public List<Game> GetAllGames()
        {
            return _context.Games.ToList();
        }

        public Game GetGameById(int id)
        {
            return _context.Games.FirstOrDefault(g => g.Id == id);
        }

        public void CreateGame(int boardGameId, List<int> playersIds)
        {
            var boardgame = _boardGamesService.GetBoardGameById(boardGameId);
            var players = _playersService.GetPlayersByIds(playersIds);

            var game = new Game
            {
                BoardGame = boardgame,
                Players = players
            };

            _context.Games.Add(game);
            _context.SaveChanges();
        }
    }
}
