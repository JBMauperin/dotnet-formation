namespace BoardgameCollectionSystem.Models
{
    public class HomeIndexViewModel
    {
        public List<Player> Players { get; set; } = new List<Player>();
        public List<Game> Games { get; set; } = new List<Game>();
        public List<BoardGame> BoardGames { get; set; } = new List<BoardGame>();
    }
}
