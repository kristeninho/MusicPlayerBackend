﻿using Moq;
using MusicPlayerBackend.Models.DTOs;
using MusicPlayerBackend.Repositories.Interfaces;

namespace MusicPlayerBackend.Tests.Repositories.Interfaces
{
	public class IUserRepositoryTests
	{
		private readonly IUserRepository _iUserRepository;
		public IUserRepositoryTests()
		{
			_iUserRepository = new Mock<IUserRepository>().Object;
		}
		[Fact]
		public void IUserRepositoryHasAddAsyncTaskTest() => Assert.True(_iUserRepository.AddAsync(new UserCredentialsDTO()) is Task<UserCredentialsDTO>);
		[Fact]
		public void IUserRepositoryHasUpdateAsyncTaskTest() => Assert.True(_iUserRepository.UpdateAsync(new UserCredentialsDTO()) is Task<UserCredentialsDTO>);
		[Fact]
		public void IUserRepositoryHasDeleteAsyncTaskTest() => Assert.True(_iUserRepository.DeleteAsync(new UserCredentialsDTO()) is Task<string>);
		[Fact]
		public void IUserRepositoryHasGetUserDataAsyncTaskTest() => Assert.True(_iUserRepository.GetUserDataAsync("User name") is Task<UserDataDTO>);
	}
}
