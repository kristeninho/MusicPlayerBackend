namespace MusicPlayerBackend.Models.DTOs
{
    public class UserDataDTO
    {
        public string Name { get; set; }
        public List<AlbumDTO>? Albums { get; set; }
        public List<SongDTO>? Songs { get; set; }
    }
}
