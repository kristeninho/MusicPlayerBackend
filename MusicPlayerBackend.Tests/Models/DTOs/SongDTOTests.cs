using MusicPlayerBackend.Models.DTOs;

namespace MusicPlayerBackend.Tests.Models.DTOs
{
	public class SongDTOTests
    {
        private readonly SongDTO _songDTO;
        public SongDTOTests()
        {
            _songDTO = new SongDTO
            {
                Id = new Guid(),
                Name = "Song Name",
                UploadDate = DateTime.Now,
                Duration = "3:00",
                SongFile = "SADSADA",
                SongNameInCloud = "SADSADSADSADSAD",
                AlbumId = new Guid(),
                UserName = "Username1"
            };
        }

        [Fact]
        public void SongDTOExistsTest() => Assert.NotNull(_songDTO);
        [Fact]
        public void SongDTOHasIdPropertyTest() => Assert.NotNull(_songDTO.Id);
        [Fact]
        public void SongDTOIdPropertyIsTypeGuidTest() => Assert.IsType<Guid>(_songDTO.Id);
        [Fact]
        public void SongDTOHasNamePropertyTest() => Assert.NotNull(_songDTO.Name);
        [Fact]
        public void SongDTONamePropertyIsTypeStringTest() => Assert.IsType<string>(_songDTO.Name);
        [Fact]
        public void SongDTOHasUploadDatePropertyTest() => Assert.NotNull(_songDTO.UploadDate);
        [Fact]
        public void SongDTOUploadDatePropertyIsTypeDateTimeTest() => Assert.IsType<DateTime>(_songDTO.UploadDate);
        [Fact]
        public void SongDTOHasDurationPropertyTest() => Assert.NotNull(_songDTO.Duration);
        [Fact]
        public void SongDTODurationPropertyIsTypeStringTest() => Assert.IsType<string>(_songDTO.Duration);
        [Fact]
        public void SongDTOHasSongFileUrlPropertyTest() => Assert.NotNull(_songDTO.SongNameInCloud);
        [Fact]
        public void SongDTOSongFileUrlPropertyIsTypeStringTest() => Assert.IsType<string>(_songDTO.SongNameInCloud);
        [Fact]
        public void SongDTOHasSongFilePropertyTest() => Assert.NotNull(_songDTO.SongFile);
        [Fact]
        public void SongDTOSongFilePropertyIsTypeStringTest() => Assert.IsType<string>(_songDTO.SongFile);
        [Fact]
        public void SongDTOHasAlbumIdPropertyTest() => Assert.NotNull(_songDTO.AlbumId);
        [Fact]
        public void SongDTOAlbumPropertyIsTypeGuidDTOTest() => Assert.IsType<Guid>(_songDTO.AlbumId);
        [Fact]
        public void SongDTOHasUserNamePropertyTest() => Assert.NotNull(_songDTO.UserName);
        [Fact]
        public void SongDTOUserNamePropertyIsTypeStringTest() => Assert.IsType<string>(_songDTO.UserName);
        [Fact]
        public void SongDTOAlbumCanBeNullTest()
        {
            var songDTOWithoutAlbum = new SongDTO
            {
                Id = new Guid(),
                Duration = "3:00",
                Name = "Song name",
                UploadDate = DateTime.Now,
                SongNameInCloud = "SDASADSADASDSAFASFSAF"
            };
            Assert.NotNull(songDTOWithoutAlbum);
            Assert.Null(songDTOWithoutAlbum.AlbumId);
        }
    }
}
