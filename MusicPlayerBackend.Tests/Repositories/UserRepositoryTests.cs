using Microsoft.EntityFrameworkCore;
using MusicPlayerBackend.Data;
using MusicPlayerBackend.Models;
using MusicPlayerBackend.Models.DTOs;
using MusicPlayerBackend.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayerBackend.Tests.Repositories
{
	public class UserRepositoryTests
	{
		private readonly IDbContextFactory<AppDbContext> _context;
		private readonly UserRepository _repository;

		public UserRepositoryTests()
		{
			_context = new TestDbContextFactory("UserInMemoryDb");
			_repository = new UserRepository(_context);
			InitializeDatabase(_context);
		}

		private void InitializeDatabase(IDbContextFactory<AppDbContext> context)
		{
			//var dbContext = context.CreateDbContext();
			//dbContext.Database.EnsureCreated();
		}

		[Fact]
		public async void UserRepository_AddAsyncTest_ValidUser()
		{
			//arrange
			var validUserCredentialsDTO = new UserCredentialsDTO
			{
				UserName = "Username",
				Password = "Password1$"
			};
			using var dbContext = _context.CreateDbContext();

			//act
			var addUserResult = await _repository.AddAsync(validUserCredentialsDTO);
			var newUserInDatabase = await dbContext.Users.FirstOrDefaultAsync(u => u.Name == validUserCredentialsDTO.UserName);

			//assert
			Assert.NotNull(addUserResult);
			Assert.Equal(validUserCredentialsDTO, addUserResult);
			Assert.NotNull(newUserInDatabase);
			Assert.Equal(validUserCredentialsDTO.UserName, newUserInDatabase.Name);
			Assert.Equal(validUserCredentialsDTO.Password, newUserInDatabase.Password);
		}
		[Theory]
		[InlineData(null, "Password1$")] // null username
		[InlineData("Us", "Password1$")] // too short username
		[InlineData("UserWithTooLongUserName", "Password1$")] // too long username
		[InlineData("username!", "Password1$")] // punctuation in username
		[InlineData("username€", "Password1$")] // symbol in username
		[InlineData("username", null)] // null password
		[InlineData("username", "Pas!1")] // too short password
		[InlineData("username", "Password1!TooLongPasswordTooLong")] // too long password
		[InlineData("username", "Password1")] // no symbol or punctuation in password
		[InlineData("username", "Password!")] // no number in password
		[InlineData("username", "password1!")] // no uppercase char in password
		public async void UserRepository_AddAsyncTest_InvalidUser(string userName, string password)
		{
			//arrange
			var invalidUserCredentialsDTO = new UserCredentialsDTO
			{
				UserName = userName,
				Password = password
			};
			using var dbContext = _context.CreateDbContext();

			//act
			var addUserResult = await _repository.AddAsync(invalidUserCredentialsDTO);
			var userInDatabase = await dbContext.Users.FirstOrDefaultAsync(u => u.Name == invalidUserCredentialsDTO.UserName);

			//assert
			Assert.Null(addUserResult);
			Assert.Null(userInDatabase);
		}
		[Fact]
		public async void UserRepository_DeleteAsyncTest_UserExists()
		{
			//arrange
			var validUserCredentialsDTO = new UserCredentialsDTO
			{
				UserName = "Username",
				Password = "Password1$"
			};
			using var dbContext = _context.CreateDbContext();

			//act
			await _repository.AddAsync(validUserCredentialsDTO);
			var deleteUserResult = await _repository.DeleteAsync(validUserCredentialsDTO);
			var expectedResult = "User deleted";

			//assert
			Assert.Equal(expectedResult, deleteUserResult);
		}
		[Fact]
		public async void UserRepository_DeleteAsyncTest_UserDoesNotExist()
		{
			//arrange
			var validUserCredentialsDTO = new UserCredentialsDTO
			{
				UserName = "Username",
				Password = "Password1$"
			};

			//act
			var deleteUserResult = await _repository.DeleteAsync(validUserCredentialsDTO);
			var expectedResult = "User does not exist";

			//assert
			Assert.Equal(expectedResult, deleteUserResult);
		}
		[Fact]
		public async void UserRepository_DeleteAsyncTest_InvalidRequest()
		{
			//arrange
			var invalidUserCredentialsDTO = new UserCredentialsDTO();

			//act
			var deleteUserResult = await _repository.DeleteAsync(invalidUserCredentialsDTO);
			var expectedResult = "Invalid request";

			//assert
			Assert.Equal(expectedResult, deleteUserResult);
		}
		[Fact]
		public async void UserRepository_UpdateAsyncTest_UserUpdated()
		{
			//arrange
			var initialUserCredentialsDTO = new UserCredentialsDTO
			{
				UserName = "Username2",
				Password = "Password2$"
			};
			var updatedUserCredentialsDTO = new UserCredentialsDTO
			{
				UserName = "Username2",
				Password = "NewPassword2$"
			};
			using var dbContext = _context.CreateDbContext();

			//act
			await _repository.AddAsync(initialUserCredentialsDTO);
			var updateUserResult = await _repository.UpdateAsync(updatedUserCredentialsDTO);
			var expectedResult = updatedUserCredentialsDTO;

			//assert
			Assert.Equal(expectedResult, updateUserResult);
		}
		[Fact]
		public async void UserRepository_UpdateAsyncTest_InvalidNewUserCredentials()
		{
			//arrange
			var updatedUserCredentialsDTO = new UserCredentialsDTO
			{
				UserName = "Username2",
				Password = "NewPassword2"
			};

			//act
			var updateUserResult = await _repository.UpdateAsync(updatedUserCredentialsDTO);
			UserCredentialsDTO? expectedResult = null;

			//assert
			Assert.Equal(expectedResult, updateUserResult);
		}
		[Fact]
		public async void UserRepository_UpdateAsyncTest_UserDoesNotExist()
		{
			//arrange
			var userCredentialsDTO = new UserCredentialsDTO
			{
				UserName = "Username3",
				Password = "NewPassword3$"
			};

			//act
			var updateUserResult = await _repository.UpdateAsync(userCredentialsDTO);
			UserCredentialsDTO? expectedResult = null;

			//assert
			Assert.Equal(expectedResult, updateUserResult);
		}
		//[Fact]
		//public async void UserRepository_GetUserDataAsyncTest_GetsDataSuccessfully()
		//{
		//	//arrange
		//	string userName = "Username4";
		//	using var dbContext = _context.CreateDbContext();
		//	InitializeDatabase(dbContext, userName);

		//	//act
		//	var updateUserResult = await _repository.GetUserDataAsync(userName);
		//	UserDataDTO? expectedResult = null;

		//	//assert
		//	Assert.Equal(expectedResult, updateUserResult);
		//}

		//private async void InitializeDatabase(AppDbContext dbContext, string userName)
		//{
		//	var validUserCredentialsDTO = new UserCredentialsDTO
		//	{
		//		UserName = userName,
		//		Password = "Password4$"
		//	};
		//	await _repository.AddAsync(validUserCredentialsDTO);

		//	var songList = new List<Song>
		//	{
		//		new Song
		//		{
		//			Name = "Song1",
		//			Duration = "3:00",
		//			SongFile = new byte[100],
		//			UploadDate = DateTime.Now
		//		},
		//		new Song
		//		{
		//			Name = "Song2",
		//			Duration = "2:00",
		//			SongFile = new byte[100],
		//			UploadDate = DateTime.Now
		//		},
		//		new Song
		//		{
		//			Name = "Song2",
		//			Duration = "4:00",
		//			SongFile = new byte[100],
		//			UploadDate = DateTime.Now
		//		}
		//	};

		//	var album = new Album
		//	{
		//		Name = "Album1",
		//		CoverImage = new byte[100],
		//		Duration = "9:00",
		//		Songs = songList,
		//		UploadDate = DateTime.Now
		//	};
		//	await dbContext.Albums.AddAsync(album);
		//	await dbContext.SaveChangesAsync();

		//	var albumsFromDb = await dbContext.Albums.Where(a => a.Name == "Album1").ToListAsync();
		//	var user = await dbContext.Users.FirstOrDefaultAsync(u => u.Name == userName);
		//	user.Albums = albumsFromDb;
		//	await dbContext.SaveChangesAsync();
		//}
	}
}
