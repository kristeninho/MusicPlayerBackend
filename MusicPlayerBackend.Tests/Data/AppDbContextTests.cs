using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using EntityFrameworkCore.Testing.Moq;
using Microsoft.EntityFrameworkCore;
using Moq;
using MusicPlayerBackend.Data;
using MusicPlayerBackend.Models;

namespace MusicPlayerBackend.Tests.Data
{
    public class AppDbContextTests
    {
        private readonly AppDbContext _context;
        public AppDbContextTests()
        {
            _context = Create.MockedDbContextFor<AppDbContext>();
        }

        [Fact]
        public void AppDbContextExistsTest() => Assert.NotNull(_context);
        [Fact]
        public void AppDbContextHasDbSetWithTypeUserTest() => Assert.True(_context.Users is DbSet<User>);
        [Fact]
        public void AppDbContextHasDbSetWithTypeSongTest() => Assert.True(_context.Songs is DbSet<Song>);
        [Fact]
        public void AppDbContextHasDbSetWithTypeAlbumTest() => Assert.True(_context.Albums is DbSet<Song>);

    }
}
