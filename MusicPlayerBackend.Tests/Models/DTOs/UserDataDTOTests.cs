using MusicPlayerBackend.Models.DTOs;

namespace MusicPlayerBackend.Tests.Models.DTOs
{
	public class UserDataDTOTests
    {
        private readonly UserDataDTO _userDataDTO;
        public UserDataDTOTests()
        {
            _userDataDTO = new UserDataDTO()
            {
                Name = "User Name",
                Songs = new List<SongDTO>(),
                Albums = new List<AlbumDTO>(),
            };
        }

        [Fact]
        public void UserDataDTOExistsTest() => Assert.NotNull(_userDataDTO);
        [Fact]
        public void UserDataDTOHasNamePropertyTest() => Assert.NotNull(_userDataDTO.Name);
        [Fact]
        public void UserDataDTONamePropertyIsTypeStringTest() => Assert.IsType<string>(_userDataDTO.Name);
        [Fact]
        public void UserDataDTOHasSongsPropertyTest() => Assert.NotNull(_userDataDTO.Songs);
        [Fact]
        public void UserDataDTOSongsPropertyIsTypeSongListTest() => Assert.IsType<List<SongDTO>>(_userDataDTO.Songs);
        [Fact]
        public void UserDataDTOHasAlbumsPropertyTest() => Assert.NotNull(_userDataDTO.Albums);
        [Fact]
        public void UserDataDTOAlbumsPropertyIsTypeAlbumListTest() => Assert.IsType<List<AlbumDTO>>(_userDataDTO.Albums);
		[Fact]
		public void UserDataDTOAlbumsCanBeNullTest()
		{
            var userDTOWithNoAlbums = new UserDataDTO()
            {
                Name = "User Name",
                Songs = new List<SongDTO>()
            };

            Assert.NotNull(userDTOWithNoAlbums);
            Assert.Null(userDTOWithNoAlbums.Albums);
        }
        [Fact]
        public void UserDataDTOSongsCanBeNullTest()
        {
            var userDTOWithNoSongs = new UserDataDTO()
            {
                Name = "User Name",
                Albums = new List<AlbumDTO>()
            };

            Assert.NotNull(userDTOWithNoSongs);
            Assert.Null(userDTOWithNoSongs.Songs);
        }
    }
}
