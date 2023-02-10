using Microsoft.EntityFrameworkCore;
using Moq;
using MusicPlayerBackend.Data;
using MusicPlayerBackend.Models;
using MusicPlayerBackend.Models.DTOs;
using MusicPlayerBackend.Repositories;
using MusicPlayerBackend.Repositories.Interfaces;
using MusicPlayerBackend.Tests.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MusicPlayerBackend.Tests.Repositories
{
    public class SongRepositoryTests
    {
        private readonly IDbContextFactory<AppDbContext> _context;
        private readonly SongRepository _repository;
		private readonly SongDTOs _songDTOs;
		private readonly AlbumDTOs _albumDTOs;
        private readonly Mock<IAzureCloudStorageRepository> _azureCloudRepository;
        public SongRepositoryTests()
        {
            _context = new TestDbContextFactory("SongInMemoryDb");
            _repository = new SongRepository(_context);
			_songDTOs = new SongDTOs();
			_albumDTOs = new AlbumDTOs();
			_azureCloudRepository = new Mock<IAzureCloudStorageRepository>();
        }

		[Fact]
		public async void SongRepository_AddAsyncTest_ValidSongDTO_AddToDEMOS()
		{
			//arrange
			var demosAlbum = _albumDTOs.GetAlbumDTO("DEMOS");
			var validSongDTO = _songDTOs.GetSongDTO("validSongDTO1");
			using var dbContext = _context.CreateDbContext();
			await InitializeDatabaseWithAnUser(dbContext, demosAlbum);
			_azureCloudRepository.Setup(x => x.UploadFileToCloudAndReturnName(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
				.ReturnsAsync("ssadasdsadasdas");

			//act
			var addSongResult = await _repository.AddAsync(validSongDTO);
			var expectedJson = JsonSerializer.Serialize(validSongDTO);
			var actualJson = JsonSerializer.Serialize(addSongResult);

			//assert
			Assert.NotNull(addSongResult);
			Assert.Equal(expectedJson, actualJson);
		}
		[Fact]
		public async void SongRepository_AddAsyncTest_ValidSongDTO_AddToAlbum()
		{
			//arrange
			var album = _albumDTOs.GetAlbumDTO("validAlbumDTO1");
			var validSongDTO = _songDTOs.GetSongDTO("validSongDTO2");
			using var dbContext = _context.CreateDbContext();
			await InitializeDatabaseWithAnUser(dbContext, album);
            _azureCloudRepository.Setup(x => x.UploadFileToCloudAndReturnName(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
                .ReturnsAsync("ssadasdsadasdas");

            //act
            var addSongResult = await _repository.AddAsync(validSongDTO);
			var expectedJson = JsonSerializer.Serialize(validSongDTO);
			var actualJson = JsonSerializer.Serialize(addSongResult);

			//assert
			Assert.NotNull(addSongResult);
			Assert.Equal(expectedJson, actualJson);
		}
		[Fact]
		public async void SongRepository_DeleteAsyncTest_SongDeleted()
		{
			//arrange
			var album = _albumDTOs.GetAlbumDTO("validAlbumDTO2");
			var validSongDTO = _songDTOs.GetSongDTO("validSongDTO3");
			using var dbContext = _context.CreateDbContext();
			await InitializeDatabaseWithAnUser(dbContext, album);
            _azureCloudRepository.Setup(x => x.UploadFileToCloudAndReturnName(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
                .ReturnsAsync("ssadasdsadasdas");
            await _repository.AddAsync(validSongDTO);
            _azureCloudRepository.Setup(x => x.DeleteAsync(It.IsAny<string>(), It.IsAny<string>()))
                .ReturnsAsync(true);

            //act
            var removeSongResult = await _repository.DeleteAsync(validSongDTO.Id.ToString());

			//assert
			Assert.NotNull(removeSongResult);
			Assert.Equal("Song deleted", removeSongResult);
		}
		[Fact]
		public async void SongRepository_DeleteAsyncTest_SongDoesNotExist()
		{
			//arrange
			var album = _albumDTOs.GetAlbumDTO("validAlbumDTO3");
			var validSongDTO = _songDTOs.GetSongDTO("validSongDTO4");
			using var dbContext = _context.CreateDbContext();
			await InitializeDatabaseWithAnUser(dbContext, album);

			//act
			var removeSongResult = await _repository.DeleteAsync(validSongDTO.Id.ToString());

			//assert
			Assert.NotNull(removeSongResult);
			Assert.Equal("Song does not exist", removeSongResult);
		}
		[Fact]
		public async void SongRepository_UpdateAsyncTest_SongUpdated()
		{
			//arrange
			var album = _albumDTOs.GetAlbumDTO("validAlbumDTO4");
			var validSongDTO = _songDTOs.GetSongDTO("validSongDTO5"); //same id
			using var dbContext = _context.CreateDbContext();
			await InitializeDatabaseWithAnUser(dbContext, album);
            _azureCloudRepository.Setup(x => x.UploadFileToCloudAndReturnName(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
                .ReturnsAsync("ssadasdsadasdas");
            await _repository.AddAsync(validSongDTO);

			var updatedSongDTO = _songDTOs.GetSongDTO("validSongDTO6"); //same id

			//act
			var updateSongResult = await _repository.UpdateAsync(updatedSongDTO);

			//assert
			Assert.NotNull(updateSongResult);
			Assert.Equal(updatedSongDTO, updateSongResult);
		}
		[Fact]
		public async void SongRepository_UpdateAsyncTest_SongDoesNotExist()
		{
			//arrange
			var album = _albumDTOs.GetAlbumDTO("validAlbumDTO7");
			using var dbContext = _context.CreateDbContext();
			await InitializeDatabaseWithAnUser(dbContext, album);

			var updatedSongDTO = _songDTOs.GetSongDTO("validSongDTO7");

			//act
			var updateSongResult = await _repository.UpdateAsync(updatedSongDTO);

			//assert
			Assert.Null(updateSongResult);
		}

		private async Task InitializeDatabaseWithAnUser(AppDbContext dbContext, AlbumDTO albumDTO)
		{
			var user = new User
			{
				Name = albumDTO.UserName,
				Id = Guid.NewGuid(),
				Password = "Password1$"
			};

			await dbContext.Users.AddAsync(user);
			await dbContext.SaveChangesAsync();

			var u = await dbContext.Users.FirstAsync(x => x.Name == albumDTO.UserName);

			var album = new Album
			{
				Id = albumDTO.Id,
				CoverImageNameInCloud = albumDTO.CoverImageNameInCloud,
				Name = albumDTO.Name,
				UploadDate = albumDTO.UploadDate,
				User = u,
				Songs = new List<Song>()
			};

			await dbContext.AddAsync(album);
			await dbContext.SaveChangesAsync();
		}
	}
}
