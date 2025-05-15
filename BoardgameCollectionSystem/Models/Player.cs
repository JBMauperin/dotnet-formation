using System.ComponentModel.DataAnnotations;

namespace BoardgameCollectionSystem.Models
{
    public class Player
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        [MaxLength(150)]
        public string Email { get; set; }
        public string Password { get; set; }

        public string Phone { get; set; } = null;

        public List<Game> Games { get; set; } = new List<Game>();

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}
