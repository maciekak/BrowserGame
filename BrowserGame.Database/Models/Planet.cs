using System.ComponentModel.DataAnnotations;

namespace BrowserGame.Database.Models
{
    public class Planet
    {
        [Key]
        public int Id { get; set; }
        public int Size { get; set; }
    }
}
