using Moq;
using MusicPlayerBackend.Models.DTOs;
using MusicPlayerBackend.Repositories.Interfaces;

namespace MusicPlayerBackend.Tests.Repositories.Interfaces
{
	public class IAlbumRepositoryTests
	{
		private readonly IAlbumRepository _iAlbumRepository;
		public IAlbumRepositoryTests()
		{
			_iAlbumRepository = new Mock<IAlbumRepository>().Object;
		}
		[Fact]
		public void IAlbumRepositoryHasAddAsyncTaskTest() => Assert.True(_iAlbumRepository.AddAsync(new AlbumDTO()) is Task<AlbumDTO>);
		[Fact]
		public void IAlbumRepositoryHasUpdateAsyncTaskTest() => Assert.True(_iAlbumRepository.UpdateAsync(new AlbumDTO()) is Task<AlbumDTO>);
		[Fact]
		public void IAlbumRepositoryHasDeleteAsyncTaskTest() => Assert.True(_iAlbumRepository.DeleteAsync("") is Task<string>);
	}
}
