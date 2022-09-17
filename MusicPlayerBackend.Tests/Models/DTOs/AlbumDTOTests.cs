using MusicPlayerBackend.Models.DTOs;

namespace MusicPlayerBackend.Tests.Models.DTOs
{
	public class AlbumDTOTests
    {
        private readonly AlbumDTO _albumDTO;
        public AlbumDTOTests()
        {
            _albumDTO = new AlbumDTO()
            {
                Id = new Guid(),
                Name = "Album name",
                Duration = "30:00",
                UploadDate = DateTime.Now,
                CoverImage = new byte[100],
                Songs = new List<SongDTO>()
            };
        }

        [Fact]
        public void AlbumDTOExistsTest() => Assert.NotNull(_albumDTO);
        [Fact]
        public void AlbumDTOHasIdPropertyTest() => Assert.NotNull(_albumDTO.Id);
        [Fact]
        public void AlbumDTOIdPropertyIsTypeGuidTest() => Assert.IsType<Guid>(_albumDTO.Id);
        [Fact]
        public void AlbumDTOHasNamePropertyTest() => Assert.NotNull(_albumDTO.Name);
        [Fact]
        public void AlbumDTONamePropertyIsTypeStringTest() => Assert.IsType<string>(_albumDTO.Name);
        [Fact]
        public void AlbumDTOHasUploadDatePropertyTest() => Assert.NotNull(_albumDTO.UploadDate);
        [Fact]
        public void AlbumDTOUploadDatePropertyIsTypeDateTimeTest() => Assert.IsType<DateTime>(_albumDTO.UploadDate);
        [Fact]
        public void AlbumDTOHasDurationPropertyTest() => Assert.NotNull(_albumDTO.Duration);
        [Fact]
        public void AlbumDTODurationPropertyIsTypeStringTest() => Assert.IsType<string>(_albumDTO.Duration);
        [Fact]
        public void AlbumDTOHasCoverImagePropertyTest() => Assert.NotNull(_albumDTO.CoverImage);
        [Fact]
        public void AlbumDTOCoverImagePropertyIsTypeByteArrayTest() => Assert.IsType<byte[]>(_albumDTO.CoverImage);
        [Fact]
        public void AlbumDTOHasSongsPropertyTest() => Assert.NotNull(_albumDTO.Songs);
        [Fact]
        public void AlbumDTOSongsPropertyIsTypeListSongDTOTest() => Assert.IsType<List<SongDTO>>(_albumDTO.Songs);
    }
}
