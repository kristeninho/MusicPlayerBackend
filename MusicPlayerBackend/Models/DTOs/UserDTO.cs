namespace MusicPlayerBackend.Models.DTOs
{
    public class UserDTO
    {
        public string Name { get; set; }
        public List<SongDTO> Songs { get; set; }
        public List<AlbumDTO>? Albums { get; set; }
    }
}
