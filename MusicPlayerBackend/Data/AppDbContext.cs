using Microsoft.EntityFrameworkCore;
using MusicPlayerBackend.Models;

namespace MusicPlayerBackend.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Song> Songs { get; set; }
        public DbSet<Album> Albums { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<User>()
                .HasMany(u => u.Albums)
                .WithOne(a=>a.User);
            mb.Entity<Album>()
                .HasMany(a => a.Songs)
                .WithOne(s => s.Album);
        }
    }
}
