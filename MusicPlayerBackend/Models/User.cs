namespace MusicPlayerBackend.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public ICollection<Song>? Songs { get; set; }
        public ICollection<Album>? Albums { get; set; }
    }
}
