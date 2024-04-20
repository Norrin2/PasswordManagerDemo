namespace PasswordManager.Models
{
    public class PasswordCard
    {
        public string Password { get; set; }
        public string Username { get; set; }
        public string Url { get; set; }
        public string Name { get; set; }
        public Guid? Id { get; set; }
    }
}
