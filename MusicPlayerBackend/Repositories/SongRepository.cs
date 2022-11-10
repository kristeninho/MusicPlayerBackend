using Microsoft.EntityFrameworkCore;
using MusicPlayerBackend.Data;
using MusicPlayerBackend.Helpers;
using MusicPlayerBackend.Models;
using MusicPlayerBackend.Models.DTOs;
using MusicPlayerBackend.Repositories.Interfaces;
using System.Text;

namespace MusicPlayerBackend.Repositories
{
    public class SongRepository : ISongRepository
    {
        private readonly IDbContextFactory<AppDbContext> _context;
        private readonly Validator _validator;
        public SongRepository(IDbContextFactory<AppDbContext> context)
        {
            _context = context;
            _validator = new Validator();
        }

        public async Task<SongDTO?> AddAsync(SongDTO songDTO)
        {
            using var dbContext = _context.CreateDbContext();
            
            //Checking if album exists. If not then add to general "DEMOS" album
            var album = await dbContext.Albums.SingleOrDefaultAsync(x=>x.Id==songDTO.AlbumId);
            if (album == null) album = await dbContext.Albums.SingleOrDefaultAsync(x => x.Name.ToUpper() == "DEMOS"); //the general album
            if (album == null) return null; //if for some reason user does not have general album named DEMOS

            var song = new Song()
            {
                Id = songDTO.Id,
                Name = songDTO.Name,
                Album = album,
                Duration = songDTO.Duration,
                SongFile = Encoding.ASCII.GetBytes(songDTO.SongFile),
                UploadDate = songDTO.UploadDate
            };

            await dbContext.AddAsync(song);
            await dbContext.SaveChangesAsync();

            return songDTO;
        }

        public async Task<string> DeleteAsync(string songId)
        {
            using var dbContext = _context.CreateDbContext();
            var song = await dbContext.Songs.FirstOrDefaultAsync(x => x.Id == new Guid(songId));
            if (song == null) return "Song does not exist";

            dbContext.Songs.Remove(song);
            await dbContext.SaveChangesAsync();

            return "Song deleted";
        }

        public async Task<SongDTO?> UpdateAsync(SongDTO songDTO)
        {
            using var dbContext = _context.CreateDbContext();

            var song = await dbContext.Songs.FirstOrDefaultAsync(x => x.Id == songDTO.Id);
            if (song == null) return null;

            song.UploadDate = songDTO.UploadDate;
            song.Duration = songDTO.Duration;
            song.SongFile = Encoding.ASCII.GetBytes(songDTO.SongFile);
            song.Name = songDTO.Name;

            var newAlbum = await dbContext.Albums.FirstOrDefaultAsync(x => x.Id == songDTO.AlbumId);
            if (newAlbum != null) song.Album = newAlbum;

            await dbContext.SaveChangesAsync();

            return songDTO;
        }

        public async Task<bool> CheckIfSongExists(Guid songId)
        {
            var dbContext = _context.CreateDbContext();

            return await dbContext.Albums.AnyAsync(x => x.Id == songId);
        }
    }
}
