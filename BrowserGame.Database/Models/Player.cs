using System.ComponentModel.DataAnnotations.Schema;

namespace BrowserGame.Database.Models
{
    public class Player
    {
        public int Id { get; set; }
        [ForeignKey(nameof(User))]
        public int UserId { get; set; }
        [ForeignKey(nameof(Planet))]
        public int PlanetId { get; set; }
        public Planet Planet { get; set; }
        public Account User { get; set; }
    }
}
