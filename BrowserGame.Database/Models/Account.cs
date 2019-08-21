using System.ComponentModel.DataAnnotations;

namespace BrowserGame.Database.Models
{
    public class Account
    {
        [Key]
        public int Id { get; set; }

        public string Username { get; set; }
        public byte[] PasswordHash { get; set; }
        public string Email { get; set; }

    }
}
