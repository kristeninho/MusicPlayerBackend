using MusicPlayerBackend.Models.DTOs;

namespace MusicPlayerBackend.Tests.Models.DTOs
{
	public class UserCredentialsDTOTests
	{
		private readonly UserCredentialsDTO _userCredentialsDTO;
		public UserCredentialsDTOTests()
		{
			_userCredentialsDTO = new UserCredentialsDTO()
			{
				UserName = "User Name",
				Password = "Password"
			};
		}

		[Fact]
		public void UserCredentialsDTOExistsTest() => Assert.NotNull(_userCredentialsDTO);
		[Fact]
		public void UserCredentialsDTOHasUserNamePropertyTest() => Assert.NotNull(_userCredentialsDTO.UserName);
		[Fact]
		public void UserCredentialsDTOUserNamePropertyIsTypeStringTest() => Assert.IsType<string>(_userCredentialsDTO.UserName);
		[Fact]
		public void UserCredentialsDTOHasPasswordPropertyTest() => Assert.NotNull(_userCredentialsDTO.Password);
		[Fact]
		public void UserCredentialsDTOPasswordPropertyIsTypeStringTest() => Assert.IsType<string>(_userCredentialsDTO.Password);
	}
}
