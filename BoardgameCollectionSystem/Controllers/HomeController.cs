using BoardgameCollectionSystem.Models;
using BoardgameCollectionSystem.Services;
using BoardgameCollectionSystem.Repository;
using Microsoft.AspNetCore.Mvc;

namespace BoardgameCollectionSystem.Controllers
{
    [Route("")]
    public class HomeController : Controller
    {
        private readonly PlayersService _playersService;
        private readonly GamesService _gamesService;
        private readonly BoardGamesService _boardGamesService;

        public HomeController(LudoManagerDbContext context, PlayersService playersService, BoardGamesService boardGamesService, GamesService gamesService)
        {
            _playersService = playersService;
            _gamesService = gamesService;
            _boardGamesService = boardGamesService;
        }

        [Route("")]
        public IActionResult Index()
        {
            List<Player> players = _playersService.GetAllPlayers();
            List<Game> games = _gamesService.GetAllGames();
            List<BoardGame> boardGames = _boardGamesService.GetAllBoardGames();

            HomeIndexViewModel model = new HomeIndexViewModel();
            model.Players = players;
            model.Games = games;
            model.BoardGames = boardGames;

            return View(model);
        }

        [HttpGet]
        [Route("game/creation")]
        public IActionResult GameCreation()
        {
            var players = _playersService.GetAllPlayers();
            var boardGames = _boardGamesService.GetAllBoardGames();

            var model = new GameCreationViewModel
            {
                Players = players,
                BoardGames = boardGames
            };

            return View(model);
        }

        [HttpPost]
        [Route("game/creation")]
        public IActionResult CreateGame()
        {
            var formValues = Request.Form;
            int gameId = int.Parse(formValues["gameId"]);
            string[] playersIdInString = formValues["playerIds"].ToString().Split(',');
            List<int> playerIds = playersIdInString.Select(int.Parse).ToList();

            _gamesService.CreateGame(gameId, playerIds);

            return RedirectToAction("Index");
        }
    }
}
