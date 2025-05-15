namespace BoardgameCollectionSystem.Models
{
    public class Game
    {
        public int Id { get; set; }
        public List<Player> Players { get; set; } = new List<Player>();
        public BoardGame BoardGame { get; set; } = new BoardGame();
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}
