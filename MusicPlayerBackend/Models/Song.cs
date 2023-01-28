namespace MusicPlayerBackend.Models
{
    public class Song
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime UploadDate { get; set; }
        public string Duration { get; set; }
        public string SongNameInCloud { get; set; }
        public Album Album { get; set; }
    }
}
