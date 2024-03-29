﻿using MusicPlayerBackend.Models;

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
                Password = "Password",
                Id = new Guid(),
                Albums = new List<Album>()
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
        public void UserNameIsTypeStringTest() => Assert.IsType<string>(_user.Name);
        [Fact]
        public void UserModelHasPasswordPropertyTest() => Assert.NotNull(_user.Password);
        [Fact]
        public void UserPasswordIsTypeStringTest() => Assert.IsType<string>(_user.Password);
        [Fact]
        public void UserModelHasAlbumsPropertyTest() => Assert.NotNull(_user.Albums);
        [Fact]
        public void UserAlbumsIsTypeICollectionAlbumTest() => Assert.IsAssignableFrom<ICollection<Album>>(_user.Albums);
        [Fact]
        public void UserAlbumsCanBeNullTest()
        {
            var userWithNoAlbums = new User()
            {
                Name = "User Name",
                Id = new Guid()
            };
            Assert.NotNull(userWithNoAlbums);
            Assert.Null(userWithNoAlbums.Albums);
        }
    }
}
