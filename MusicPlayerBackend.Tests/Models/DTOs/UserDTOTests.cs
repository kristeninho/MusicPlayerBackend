using MusicPlayerBackend.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayerBackend.Tests.Models.DTOs
{
    public class UserDTOTests
    {
        private readonly UserDTO _userDTO;
        public UserDTOTests()
        {
            _userDTO = new UserDTO()
            {
                Name = "User Name",
                Songs = new List<SongDTO>(),
                Albums = new List<AlbumDTO>(),
            };
        }

        [Fact]
        public void UserDTOExistsTest() => Assert.NotNull(_userDTO);
        [Fact]
        public void UserDTOHasNamePropertyTest() => Assert.NotNull(_userDTO.Name);
        [Fact]
        public void UserDTONamePropertyIsTypeStringTest() => Assert.IsType<string>(_userDTO.Name);
        [Fact]
        public void UserDTOHasSongsPropertyTest() => Assert.NotNull(_userDTO.Songs);
        [Fact]
        public void UserDTOSongsPropertyIsTypeSongListTest() => Assert.IsType<List<SongDTO>>(_userDTO.Songs);
        [Fact]
        public void UserDTOHasAlbumsPropertyTest() => Assert.NotNull(_userDTO.Albums);
        [Fact]
        public void UserDTOAlbumsPropertyIsTypeAlbumListTest() => Assert.IsType<List<AlbumDTO>>(_userDTO.Albums);
    }
}
