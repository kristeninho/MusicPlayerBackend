using Microsoft.EntityFrameworkCore;
using MusicPlayerBackend.Data;
using MusicPlayerBackend.Models;
using MusicPlayerBackend.Models.DTOs;
using MusicPlayerBackend.Repositories;
using System.Text.Json;
using MusicPlayerBackend.Repositories.Interfaces;
using Moq;

namespace MusicPlayerBackend.Tests.Repositories
{
	public class UserRepositoryTests
	{
		private readonly IDbContextFactory<AppDbContext> _context;
		private readonly UserRepository _repository;
        private readonly Mock<IAzureCloudStorageRepository> _azureCloudRepository;
        public UserRepositoryTests()
		{
			_context = new TestDbContextFactory("UserInMemoryDb");
			_repository = new UserRepository(_context);
            _azureCloudRepository = new Mock<IAzureCloudStorageRepository>();
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
			Assert.Equal("03D926C0F0E6AEDD1C858A91DCDFA01E50205A8EA1D1D570BF2BCC741D63691BB2C70537AC7F98425157DD1750839357442F3834F2F6EAE54262A8E2A99F65E0", newUserInDatabase.Password);

        }

		// TODO: This test has to be moved, since the username validation was moved

		//[Theory]
		//[InlineData(null, "Password1$")] // null username
		//[InlineData("Us", "Password1$")] // too short username
		//[InlineData("UserWithTooLongUserName", "Password1$")] // too long username
		//[InlineData("username!", "Password1$")] // punctuation in username
		//[InlineData("username€", "Password1$")] // symbol in username
		//[InlineData("username", null)] // null password
		//[InlineData("username", "Pas!1")] // too short password
		//[InlineData("username", "Password1!TooLongPasswordTooLong")] // too long password
		//[InlineData("username", "Password1")] // no symbol or punctuation in password
		//[InlineData("username", "Password!")] // no number in password
		//[InlineData("username", "password1!")] // no uppercase char in password
		//public async void UserRepository_AddAsyncTest_InvalidUser(string userName, string password)
		//{
		//	//arrange
		//	var invalidUserCredentialsDTO = new UserCredentialsDTO
		//	{
		//		UserName = userName,
		//		Password = password
		//	};
		//	using var dbContext = _context.CreateDbContext();

		//	//act
		//	var addUserResult = await _repository.AddAsync(invalidUserCredentialsDTO);
		//	var userInDatabase = await dbContext.Users.FirstOrDefaultAsync(u => u.Name == invalidUserCredentialsDTO.UserName);

		//	//assert
		//	Assert.Null(addUserResult);
		//	Assert.Null(userInDatabase);
		//}
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
			var deleteUserResult = await _repository.DeleteAsync(validUserCredentialsDTO.UserName);
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
			var deleteUserResult = await _repository.DeleteAsync(validUserCredentialsDTO.UserName);
			var expectedResult = "User does not exist";

			//assert
			Assert.Equal(expectedResult, deleteUserResult);
		}

		// Has to be moved because of the user credentials validator
		//[Fact]
		//public async void UserRepository_DeleteAsyncTest_InvalidPassword()
		//{
		//	//arrange
		//	var invalidUserCredentialsDTO = new UserCredentialsDTO();

		//	//act
		//	var deleteUserResult = await _repository.DeleteAsync(invalidUserCredentialsDTO);
		//	var expectedResult = "Invalid Password";

		//	//assert
		//	Assert.Equal(expectedResult, deleteUserResult);
		//}
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
		[Fact]
		public async void UserRepository_GetUserDataAsyncTest_GetsDataSuccessfully()
		{
			//arrange
			string userName = "Username4";
			using var dbContext = _context.CreateDbContext();
			var user = await InitializeDatabaseAndReturnUser(dbContext, userName);
			var userDTO = TransferUserDataToDTO(user);
			_azureCloudRepository.Setup(x => x.DownloadFileAndReturnAsString(It.IsAny<string>(), It.IsAny<string>())).ReturnsAsync("AAAAA");
            ///_azureCloudRepository.Setup(x => x.DownloadFileAndReturnAsString(It.IsAny<string>(), "songs")).ReturnsAsync("BBBBB");

            //act
            var getUserDataResult = await _repository.GetUserDataAsync(userName);

			var expectedJson = JsonSerializer.Serialize(userDTO);
			var actualJson = JsonSerializer.Serialize(getUserDataResult);

			//assert
			Assert.Equal(expectedJson, actualJson);
		}
		[Theory]
		[InlineData(null)] // null username
		[InlineData("Us")] // too short username
		[InlineData("UserWithTooLongUserName")] // too long username
		[InlineData("username!")] // punctuation in username
		[InlineData("username€")] // symbol in username
		public async void UserRepository_GetUserDataAsyncTest_InvalidUsername(string userName)
		{
			//arrange

			//act
			var getUserDataResult = await _repository.GetUserDataAsync(userName);

			//assert
			Assert.Null(getUserDataResult);
		}
		[Fact]
		public async void UserRepository_GetUserDataAsyncTest_UserDoesNotExist()
		{
			//arrange
			string userName = "Username5";

			//act
			var getUserDataResult = await _repository.GetUserDataAsync(userName);

			//assert
			Assert.Null(getUserDataResult);
		}
        [Fact]
        public async void UserRepository_CheckIfUserWithSameNameAndPasswordExistsTest_UserExists()
        {
            //arrange
            var validUserCredentialsDTO = new UserCredentialsDTO
            {
                UserName = "Username9",
                Password = "Password9$"
            };
			await _repository.AddAsync(validUserCredentialsDTO);

            //act
            var userExistsResult = await _repository.CheckIfUserExistsByUsernameAndPassword(validUserCredentialsDTO);

            //assert
            Assert.True(userExistsResult);
        }
        [Fact]
        public async void UserRepository_CheckIfUserWithSameNameAndPasswordExistsTest_UserDoesNotExists()
        {
            //arrange
            var validUserCredentialsDTO = new UserCredentialsDTO
            {
                UserName = "Username90",
                Password = "Password9$"
            };

            //act
            var userExistsResult = await _repository.CheckIfUserExistsByUsernameAndPassword(validUserCredentialsDTO);

            //assert
            Assert.False(userExistsResult);
        }
        [Fact]
        public async void UserRepository_CheckIfUserWithSameNameExistsTest_UserExistsAlready()
        {
            //arrange
            var validUserCredentialsDTO = new UserCredentialsDTO
            {
                UserName = "Username11",
                Password = "Password9$"
            };
			await _repository.AddAsync(validUserCredentialsDTO);

            //act
            var userExistsResult = await _repository.CheckIfUserExistsByUsername(validUserCredentialsDTO.UserName);

            //assert
            Assert.True(userExistsResult);
        }
        [Fact]
        public async void UserRepository_CheckIfUserWithSameNameExistsTest_UserDoesNotExist()
        {
            //arrange
            var validUserCredentialsDTO = new UserCredentialsDTO
            {
                UserName = "Username111",
                Password = "Password9$"
            };

            //act
            var userExistsResult = await _repository.CheckIfUserExistsByUsername(validUserCredentialsDTO.UserName);

            //assert
            Assert.False(userExistsResult);
        }

        private async Task<User> InitializeDatabaseAndReturnUser(AppDbContext dbContext, string userName)
		{
			var validUserCredentialsDTO = new UserCredentialsDTO
			{
				UserName = userName,
				Password = "Password4$"
			};
			await _repository.AddAsync(validUserCredentialsDTO);

			var songList = new List<Song>
			{
				new Song
				{
					Name = "Song1",
					SongNameInCloud = "AAAAA",
					UploadDate = DateTime.Now,
				},
				new Song
				{
					Name = "Song2",
					SongNameInCloud = "AAAAA",
					UploadDate = DateTime.Now
				},
				new Song
				{
					Name = "Song2",
					SongNameInCloud = "AAAAA",
					UploadDate = DateTime.Now
				}
			};

			var album = new Album
			{
				Name = "Album1",
				CoverImageNameInCloud = "AAAAA",
				Songs = songList,
				UploadDate = DateTime.Now
			};
			await dbContext.Albums.AddAsync(album);
			await dbContext.SaveChangesAsync();

			var albumsFromDb = await dbContext.Albums.Where(a => a.Name == "Album1").ToListAsync();
			var user = await dbContext.Users.FirstOrDefaultAsync(u => u.Name == userName);
			user.Albums = albumsFromDb;
			await dbContext.SaveChangesAsync();
			return user;
		}

		private UserDataDTO TransferUserDataToDTO(User? user)
		{
			List<AlbumDTO> albumDTOs = new List<AlbumDTO>();
			List<SongDTO> songDTOs = new List<SongDTO>();
			foreach (var album in user.Albums)
			{
				var albumDTO = new AlbumDTO
				{
					Id = album.Id,
					Name = album.Name,
					UploadDate = album.UploadDate,
					UserName = user.Name,
					CoverImageNameInCloud = album.CoverImageNameInCloud,
					Songs = new List<SongDTO>()
				};

				foreach (var song in album.Songs)
				{
					var songDTO = new SongDTO
					{
						Id = song.Id,
						Name = song.Name,
						SongNameInCloud = song.SongNameInCloud,
						UploadDate = song.UploadDate,
						AlbumId = album.Id,
						UserName = user.Name
					};

					songDTOs.Add(songDTO);
					albumDTO.Songs.Add(songDTO);
				}
				albumDTOs.Add(albumDTO);
			}
			return new UserDataDTO
			{
				Name = user.Name,
				Albums = albumDTOs,
				Songs = songDTOs
			};
		}
	}
}
