namespace BoardgameCollectionSystem.Models
{
    public class GameCreationViewModel
    {
        public List<Player> Players { get; set; } = new List<Player>();
        public List<BoardGame> BoardGames { get; set; } = new List<BoardGame>();
    }
}
