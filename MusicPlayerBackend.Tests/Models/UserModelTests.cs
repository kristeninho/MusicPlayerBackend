using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using MusicPlayerBackend.Models;
using MusicPlayerBackend.Tests;

namespace MusicPlayerBackend.Tests.Models
{
    public class UserModelTests
    {
        private readonly User _user;
        public UserModelTests()
        {
            _user = new User()
            {
                Name = "User Name",
                Id = new Guid(),
                Albums = new List<Album>(),
                Songs = new List<Song>()
            };
        }

        [Fact]
        public void UserModelExistsTest() => Assert.NotNull(_user);
        [Fact]
        public void UserModelHasIdPropertyTest() => Assert.NotNull(_user.Id);
        [Fact]
        public void UserIdIsTypeGuidTest() => Assert.IsType<Guid>(_user.Id);
        [Fact]
        public void UserModelHasNamePropertyTest() => Assert.NotNull(_user.Name);
        [Fact]
        public void UserNameIsTypeStringTest() => Assert.IsType<String>(_user.Name);
        [Fact]
        public void UserModelHasSongsPropertyTest() => Assert.NotNull(_user.Songs);
        [Fact]
        public void UserSongsIsTypeICollectionSongTest() => Assert.IsAssignableFrom<ICollection<Song>>(_user.Songs);
        [Fact]
        public void UserModelHasAlbumsPropertyTest() => Assert.NotNull(_user.Albums);
        [Fact]
        public void UserAlbumsIsTypeICollectionAlbumTest() => Assert.IsAssignableFrom<ICollection<Album>>(_user.Albums);
    }
}
