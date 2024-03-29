﻿using MusicPlayerBackend.Models;

namespace MusicPlayerBackend.Tests.Models
{
	public class AlbumModelTests
    {
        private readonly Album _album;
        public AlbumModelTests()
        {
            _album = new Album()
            {
                Id = new Guid(),
                Name = "Album name",
                UploadDate = DateTime.Now,
                CoverImageNameInCloud = "SSSSSS",
                Songs = new List<Song>(),
                User = new User()
            };
        }

        [Fact]
        public void AlbumModelExistsTest() => Assert.NotNull(_album);
        [Fact]
        public void AlbumModelHasIdPropertyTest() => Assert.NotNull(_album.Id);
        [Fact]
        public void AlbumIdIsTypeGuidTest() => Assert.IsType<Guid>(_album.Id);
        [Fact]
        public void AlbumModelHasNamePropertyTest() => Assert.NotNull(_album.Name);
        [Fact]
        public void AlbumNameIsTypeStringTest() => Assert.IsType<string>(_album.Name);
        [Fact]
        public void AlbumModelHasCoverImagePropertyTest() => Assert.NotNull(_album.CoverImageNameInCloud);
        [Fact]
        public void AlbumCoverImageIsTypeStringTest() => Assert.IsType<string>(_album.CoverImageNameInCloud);
        [Fact]
        public void AlbumModelHasUploadDatePropertyTest() => Assert.NotNull(_album.UploadDate);
        [Fact]
        public void AlbumUploadDateIsTypeDateTimeTest() => Assert.IsType<DateTime>(_album.UploadDate);
        [Fact]
        public void AlbumModelHasSongsPropertyTest() => Assert.NotNull(_album.Songs);
        [Fact]
        public void AlbumSongsIsTypeICollectionSongTest() => Assert.IsAssignableFrom<ICollection<Song>>(_album.Songs);
        [Fact]
        public void AlbumModelHasUserPropertyTest() => Assert.NotNull(_album.User);
        [Fact]
        public void AlbumUserIsTypeUserTest() => Assert.IsType<User>(_album.User);
    }
}
