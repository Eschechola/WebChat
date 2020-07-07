namespace WebChat.Domain.Entities
{
    public class User : Base
    {
        public string Hash { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
    }
}
