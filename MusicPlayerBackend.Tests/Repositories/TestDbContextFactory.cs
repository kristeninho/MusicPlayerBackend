using Microsoft.EntityFrameworkCore;
using MusicPlayerBackend.Data;

namespace MusicPlayerBackend.Tests.Repositories
{
    public class TestDbContextFactory : IDbContextFactory<AppDbContext>
	{
		private DbContextOptions<AppDbContext> _options;
		public TestDbContextFactory(string dbName = "InMemoryDB")
		{
			_options = new DbContextOptionsBuilder<AppDbContext>()
			.UseInMemoryDatabase(databaseName: dbName)
			.Options;
		}

		public AppDbContext CreateDbContext()
		{
			return new AppDbContext(_options);
		}
	}
}
