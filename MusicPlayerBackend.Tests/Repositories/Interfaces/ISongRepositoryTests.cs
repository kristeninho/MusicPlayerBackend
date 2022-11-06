using Moq;
using MusicPlayerBackend.Models.DTOs;
using MusicPlayerBackend.Repositories.Interfaces;

namespace MusicPlayerBackend.Tests.Repositories.Interfaces
{
	public class ISongRepositoryTests
	{
		private readonly ISongRepository _iSongRepository;
		public ISongRepositoryTests()
		{
			_iSongRepository = new Mock<ISongRepository>().Object;
		}
		[Fact]
		public void ISongRepositoryHasAddAsyncTaskTest() => Assert.True(_iSongRepository.AddAsync(new SongDTO()) is Task<SongDTO>);
		[Fact]
		public void ISongRepositoryHasUpdateAsyncTaskTest() => Assert.True(_iSongRepository.UpdateAsync(new SongDTO()) is Task<SongDTO>);
		[Fact]
		public void ISongRepositoryHasDeleteAsyncTaskTest() => Assert.True(_iSongRepository.DeleteAsync("") is Task<string>);
	}
}
