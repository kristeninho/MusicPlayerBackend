namespace MusicPlayerBackend.Models.DTOs
{
    public class SongDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime UploadDate { get; set; }
        public string? SongNameInCloud { get; set; }
        public string? SongFile { get; set; }
        public Guid? AlbumId { get; set; }
        public string UserName { get; set; }
    }
}