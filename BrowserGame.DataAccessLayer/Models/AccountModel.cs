namespace BrowserGame.DataAccessLayer.Models
{
    public class AccountModel
    {
        public int Id { get; set; }

        public string Username { get; set; }
        public byte[] PasswordHash { get; set; }
        public string Email { get; set; }
    }
}
