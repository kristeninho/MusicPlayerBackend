using MusicPlayerBackend.Models;

namespace MusicPlayerBackend.Tests.Models
{
	public class SongModelTests
    {
        private readonly Song _song;
        public SongModelTests()
        {
            _song = new Song()
            {
                Id = new Guid(),
                Name = "Song name",
                Duration = "3.30",
                SongFile = new byte[100],
                UploadDate = DateTime.Now,
                Album = new Album()
            };
        }

        [Fact]
        public void SongModelExistsTest() => Assert.NotNull(_song);
        [Fact]
        public void SongModelHasIdPropertyTest() => Assert.NotNull(_song.Id);
        [Fact]
        public void SongIdIsTypeGuidTest() => Assert.IsType<Guid>(_song.Id);
        [Fact]
        public void SongModelHasNamePropertyTest() => Assert.NotNull(_song.Name);
        [Fact]
        public void SongNameIsTypeStringTest() => Assert.IsType<string>(_song.Name);
        [Fact]
        public void SongModelHasDurationPropertyTest() => Assert.NotNull(_song.Duration);
        [Fact]
        public void SongDurationIsTypeStringTest() => Assert.IsType<string>(_song.Duration);
        [Fact]
        public void SongModelHasSongFilePropertyTest() => Assert.NotNull(_song.SongFile);
        [Fact]
        public void SongSongFileIsTypeByteArrayTest() => Assert.IsType<byte[]>(_song.SongFile);
        [Fact]
        public void SongModelHasUploadDatePropertyTest() => Assert.NotNull(_song.UploadDate);
        [Fact]
        public void SongUploadDateIsTypeDateTimeTest() => Assert.IsType<DateTime>(_song.UploadDate);
        [Fact]
        public void SongModelHasAlbumPropertyTest() => Assert.NotNull(_song.Album);
        [Fact]
        public void SongAlbumIsTypeAlbumTest() => Assert.IsType<Album>(_song.Album);
    }
}
