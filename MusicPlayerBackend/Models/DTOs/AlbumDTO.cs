namespace MusicPlayerBackend.Models.DTOs
{
    public class AlbumDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime UploadDate { get; set; }
        public string Duration { get; set; }
        public string CoverImageUrl { get; set; }
        public List<SongDTO> Songs { get; set; }
        public string UserName { get; set; }
    }
}