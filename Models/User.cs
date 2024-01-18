namespace frontendApi.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public ICollection<Game>? Games { get; set; }
    }
}
