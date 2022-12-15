namespace MusicPlayerBackend.Models
{
    public class Album
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime UploadDate { get; set; }
        public string Duration { get; set; }
        public string CoverImageUrl { get; set; }
        public ICollection<Song> Songs { get; set; }
        public User User { get; set; }
    }
}