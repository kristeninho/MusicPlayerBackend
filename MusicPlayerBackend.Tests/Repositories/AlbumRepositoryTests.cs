using Microsoft.EntityFrameworkCore;
using MusicPlayerBackend.Data;
using MusicPlayerBackend.Models;
using MusicPlayerBackend.Models.DTOs;
using MusicPlayerBackend.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MusicPlayerBackend.Tests.Repositories
{
	public class AlbumRepositoryTests
	{
		private readonly IDbContextFactory<AppDbContext> _context;
		private readonly AlbumRepository _repository;
		public AlbumRepositoryTests()
		{
			_context = new TestDbContextFactory("AlbumInMemoryDb");
			_repository = new AlbumRepository(_context);
		}
		[Fact]
		public async void AlbumRepository_AddAsyncTest_ValidAlbum()
		{
			//arrange
			var albumId = Guid.NewGuid();
			var validAlbumDTO = new AlbumDTO
			{
				Id = albumId,
				Name = "Album1",
				UserName = "Username1",
				Duration = "30:00",
				CoverImage = new byte[100],
				UploadDate = DateTime.Now,
				Songs = new List<SongDTO>()
				{
					new SongDTO
					{
						Name = "Song1",
						Duration = "10:00",
						Id = Guid.NewGuid(),
						UploadDate = DateTime.Now,
						SongFile = new byte[100],
						AlbumId = albumId
					},
					new SongDTO
					{
						Name = "Song2",
						Duration = "12:00",
						Id = Guid.NewGuid(),
						UploadDate = DateTime.Now,
						SongFile = new byte[100],
						AlbumId = albumId
					},
					new SongDTO
					{
						Name = "Song3",
						Duration = "08:00",
						Id = Guid.NewGuid(),
						UploadDate = DateTime.Now,
						SongFile = new byte[100],
						AlbumId = albumId
					},
				}
			};
			using var dbContext = _context.CreateDbContext();
			await InitializeDatabaseWithAnUser(dbContext, validAlbumDTO.UserName);

			//act
			var addAlbumResult = await _repository.AddAsync(validAlbumDTO);
			var expectedJson = JsonSerializer.Serialize(validAlbumDTO);
			var actualJson = JsonSerializer.Serialize(addAlbumResult);

			//assert
			Assert.NotNull(addAlbumResult);
			Assert.Equal(expectedJson, actualJson);
		}

		private async Task InitializeDatabaseWithAnUser(AppDbContext dbContext, string userName)
		{
			var user = new User
			{
				Name = userName,
				Id = Guid.NewGuid(),
				Password = "Password1$"
			};

			await dbContext.Users.AddAsync(user);
			await dbContext.SaveChangesAsync();
		}
	}
}
