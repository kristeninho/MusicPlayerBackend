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
	public class AlbumRepositoryTests
	{
		private readonly IDbContextFactory<AppDbContext> _context;
		private readonly AlbumRepository _repository;
		private readonly AlbumDTOs _albumDTOs;
		private readonly Mock<IAzureCloudStorageRepository> _azureCloudRepository;
		
		public AlbumRepositoryTests()
		{
			_context = new TestDbContextFactory("AlbumInMemoryDb");
			_repository = new AlbumRepository(_context);
			_albumDTOs = new AlbumDTOs();
			_azureCloudRepository = new Mock<IAzureCloudStorageRepository>();
		}
		[Fact]
		public async void AlbumRepository_AddAsyncTest_ValidAlbumDTO()
		{
			//arrange
			var validAlbumDTO = _albumDTOs.GetAlbumDTO("validAlbumDTO1");
			using var dbContext = _context.CreateDbContext();
			await InitializeDatabaseWithAnUser(dbContext, validAlbumDTO.UserName);
            _azureCloudRepository.Setup(x => x.UploadFileToCloudAndReturnName(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
				.ReturnsAsync("abv");

            //act
            var addAlbumResult = await _repository.AddAsync(validAlbumDTO);
			var expectedJson = JsonSerializer.Serialize(validAlbumDTO);
			var actualJson = JsonSerializer.Serialize(addAlbumResult);

			//assert
			Assert.NotNull(addAlbumResult);
			Assert.Equal(expectedJson, actualJson);
		}
		[Theory]
		[InlineData("Null")]
		[InlineData("CoverImageNull")]
		[InlineData("InvalidId")]
		[InlineData("UsernameNull")]
		[InlineData("UsernameTooShort")]
		[InlineData("UsernameTooLong")]
		[InlineData("UsernameHasSymbols")]
		[InlineData("InvalidSongCount")]
		[InlineData("AlbumNameNull")]
		[InlineData("UploadDateInFuture")]
		[InlineData("InvalidSongId")]
		[InlineData("InvalidSongAlbumId")]
		[InlineData("InvalidSongDuration")]
		[InlineData("SongFileNull")]
		[InlineData("SongUploadDateInFuture")]
		public async void AlbumRepository_AddAsyncTest_InvalidValidAlbumDTO(string albumDTOType)
		{
			//arrange
			var invalidAlbumDTO = _albumDTOs.GetAlbumDTO(albumDTOType);
			using var dbContext = _context.CreateDbContext();

			//act
			var addAlbumResult = await _repository.AddAsync(invalidAlbumDTO);

			//assert
			Assert.Null(addAlbumResult);
		}
		[Fact]
		public async void AlbumRepository_AddAsyncTest_UserDoesNotExist()
		{
			//arrange
			var validAlbumDTO = _albumDTOs.GetAlbumDTO("validAlbumDTO2");
			using var dbContext = _context.CreateDbContext();

			//act
			var addAlbumResult = await _repository.AddAsync(validAlbumDTO);

			//assert
			Assert.Null(addAlbumResult);
		}
		[Fact]
		public async void AlbumRepository_DeleteAsyncTest_AlbumDeleted()
		{
			//arrange
			var validAlbumDTO = _albumDTOs.GetAlbumDTO("validAlbumDTO3");
			using var dbContext = _context.CreateDbContext();
			await InitializeDatabaseWithAnUser(dbContext, validAlbumDTO.UserName);
			await _repository.AddAsync(validAlbumDTO);
            _azureCloudRepository.Setup(x => x.DeleteAsync(It.IsAny<string>(), It.IsAny<string>())).ReturnsAsync(true);

            //act
            var deleteAlbumResult = await _repository.DeleteAsync(validAlbumDTO.Id.ToString());

			//assert
			Assert.NotNull(deleteAlbumResult);
			Assert.Equal("Album deleted", deleteAlbumResult);
		}
		[Fact]
		public async void AlbumRepository_DeleteAsyncTest_AlbumDoesNotExist()
		{
			//arrange
			var validAlbumDTO = _albumDTOs.GetAlbumDTO("validAlbumDTO2");
			using var dbContext = _context.CreateDbContext();

			//act
			var deleteAlbumResult = await _repository.DeleteAsync(validAlbumDTO.Id.ToString());

			//assert
			Assert.NotNull(deleteAlbumResult);
			Assert.Equal("Album does not exist", deleteAlbumResult);
		}
		[Fact]
		public async void AlbumRepository_UpdateAsyncTest_AlbumUpdated()
		{
			//arrange
			var validAlbumDTO = _albumDTOs.GetAlbumDTO("validAlbumDTO4");
			using var dbContext = _context.CreateDbContext();
			await InitializeDatabaseWithAnUser(dbContext, validAlbumDTO.UserName);
            _azureCloudRepository.Setup(x => x.UploadFileToCloudAndReturnName(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>())).ReturnsAsync("ssadasdsadasdas");
            await _repository.AddAsync(validAlbumDTO);

			var updatedValidAlbumDTO = _albumDTOs.GetAlbumDTO("validAlbumDTO5"); //same id as validalbumdto4

			//act
			var updateAlbumResult = await _repository.UpdateAsync(updatedValidAlbumDTO);

			//assert
			Assert.NotNull(updateAlbumResult);
			Assert.Equal(updatedValidAlbumDTO, updateAlbumResult);
		}
		[Fact]
		public async void AlbumRepository_UpdateAsyncTest_AlbumDoesNotExist()
		{
			//arrange
			var validAlbumDTO = _albumDTOs.GetAlbumDTO("validAlbumDTO6");
			using var dbContext = _context.CreateDbContext();

			//act
			var updateAlbumResult = await _repository.UpdateAsync(validAlbumDTO);

			//assert
			Assert.Null(updateAlbumResult);
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
