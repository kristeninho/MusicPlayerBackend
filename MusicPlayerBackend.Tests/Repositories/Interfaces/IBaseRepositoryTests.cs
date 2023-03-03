using Moq;
using MusicPlayerBackend.Repositories.Interfaces;

namespace MusicPlayerBackend.Tests.Repositories.Interfaces
{
	public class IBaseRepositoryTests
	{
		private IBaseRepository<TestType> _iBaseRepository;
		public IBaseRepositoryTests()
		{
			_iBaseRepository = new Mock<IBaseRepository<TestType>>().Object;
		}
		[Fact]
		public void IBaseRepositoryHasAddAsyncTaskTest() => Assert.True(_iBaseRepository.AddAsync(new TestType()) is Task<(string, string)?>);
		[Fact]
		public void IBaseRepositoryHasUpdateAsyncTaskTest() => Assert.True(_iBaseRepository.UpdateAsync(new TestType()) is Task<TestType>);
		[Fact]
		public void IBaseRepositoryHasDeleteAsyncTaskTest() => Assert.True(_iBaseRepository.DeleteAsync("") is Task<string>);
	}
	public class TestType
	{
		public string Name { get; set; }
	}
}
