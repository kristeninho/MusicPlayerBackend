using Microsoft.EntityFrameworkCore;
using MusicPlayerBackend.Data;
using MusicPlayerBackend.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayerBackend.Tests.Repositories
{
    public class SongRepositoryTests
    {
        private readonly IDbContextFactory<AppDbContext> _context;
        private readonly SongRepository _repository;
        public SongRepositoryTests()
        {
            _context = new TestDbContextFactory("SongInMemoryDb");
            _repository = new SongRepository(_context);
        }
    }
}
