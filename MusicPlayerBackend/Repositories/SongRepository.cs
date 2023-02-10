using Microsoft.EntityFrameworkCore;
using MusicPlayerBackend.Data;
using MusicPlayerBackend.Models;
using MusicPlayerBackend.Models.DTOs;
using MusicPlayerBackend.Repositories.Interfaces;

namespace MusicPlayerBackend.Repositories
{
    public class SongRepository : ISongRepository
    {
        private readonly IDbContextFactory<AppDbContext> _context;
        private readonly IAzureCloudStorageRepository _azureCloudStorage = new AzureCloudStorageRepository();
        public SongRepository(IDbContextFactory<AppDbContext> context)
        {
            _context = context;
        }

        public async Task<SongDTO?> AddAsync(SongDTO songDTO)
        {
            using var dbContext = _context.CreateDbContext();
            
            //Checking if album exists. If not then add to general "DEMOS" album
            var album = await dbContext.Albums.SingleOrDefaultAsync(x=>x.Id==songDTO.AlbumId);
            if (album == null) album = await dbContext.Albums.SingleOrDefaultAsync(x => x.Name.ToUpper() == "DEMOS"); //the general album
            if (album == null) return null; //if for some reason user does not have general album named DEMOS

            try
            {
                var song = new Song()
                {
                    Id = songDTO.Id, //might be removed so id would be generated in the BE
                    Name = songDTO.Name,
                    Album = album,
                    SongNameInCloud = await _azureCloudStorage.UploadFileToCloudAndReturnName(songDTO.UserName, songDTO.Name, "mp3", songDTO.SongFile, "songs"),
                    UploadDate = songDTO.UploadDate
                };

                await dbContext.AddAsync(song);
                await dbContext.SaveChangesAsync();

                return songDTO;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<string> DeleteAsync(string songId)
        {
            using var dbContext = _context.CreateDbContext();
            var song = await dbContext.Songs.FirstOrDefaultAsync(x => x.Id == new Guid(songId));
            if (song == null) return "Song does not exist";

            try
            {
                await _azureCloudStorage.DeleteAsync(song.SongNameInCloud, "songs");
                dbContext.Songs.Remove(song);
                await dbContext.SaveChangesAsync();

                return "Song deleted";
            }
            catch (Exception ex)
            {
                return $"EXCEPTION: {ex}";
            }
        }

        public async Task<SongDTO?> UpdateAsync(SongDTO songDTO)
        {
            using var dbContext = _context.CreateDbContext();

            var song = await dbContext.Songs.FirstOrDefaultAsync(x => x.Id == songDTO.Id);
            if (song == null) return null;

            // need to think about what exactly should be updatable
            song.UploadDate = songDTO.UploadDate;
            song.Name = songDTO.Name;

            var newAlbum = await dbContext.Albums.FirstOrDefaultAsync(x => x.Id == songDTO.AlbumId);
            if (newAlbum != null) song.Album = newAlbum;

            await dbContext.SaveChangesAsync();

            return songDTO;
        }

        public async Task<bool> CheckIfSongExists(Guid songId)
        {
            var dbContext = _context.CreateDbContext();

            return await dbContext.Songs.AnyAsync(x => x.Id == songId);
        }
    }
}
