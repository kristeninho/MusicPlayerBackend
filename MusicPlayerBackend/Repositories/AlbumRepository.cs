using Microsoft.EntityFrameworkCore;
using MusicPlayerBackend.Data;
using MusicPlayerBackend.Helpers;
using MusicPlayerBackend.Models;
using MusicPlayerBackend.Models.DTOs;
using MusicPlayerBackend.Repositories.Interfaces;
using System.Globalization;
using System.Text;

namespace MusicPlayerBackend.Repositories
{
	public class AlbumRepository : IAlbumRepository
	{
		private readonly IDbContextFactory<AppDbContext> _context;
		public AlbumRepository(IDbContextFactory<AppDbContext> context)
		{
			_context = context;
		}
		public async Task<AlbumDTO?> AddAsync(AlbumDTO albumDTO)
		{
			using var dbContext = _context.CreateDbContext();

			var user = await GetUserByUsername(albumDTO.UserName, dbContext);
			if (user == null) return null;

			var coverUrl = "";

			if (albumDTO.CoverImage == null) coverUrl = "defaultCoverImageURL"; // some default image url;
			else coverUrl = UploadCoverImage(albumDTO.CoverImage);

			var newAlbum = new Album
			{
				Id = albumDTO.Id,
				Name = albumDTO.Name,
				CoverImageUrl = coverUrl,
				Duration = albumDTO.Duration,
				UploadDate = albumDTO.UploadDate,
				User = user
			};

			newAlbum.Songs = albumDTO.Songs.Select(s => new Song
			{
				Id = s.Id,
				SongFileUrl = UploadSong(s.SongFile),
				Duration = s.Duration,
				Name = s.Name,
				UploadDate = s.UploadDate,
				Album = newAlbum
			}).ToList();

			await dbContext.AddAsync(newAlbum);
			await dbContext.SaveChangesAsync();

			return albumDTO;
		}

		public async Task<string> DeleteAsync(string albumId)
		{
			using var dbContext = _context.CreateDbContext();
			var album = await dbContext.Albums.Include(x => x.Songs).FirstOrDefaultAsync(a => a.Id == new Guid(albumId));
			if (album == null) return "Album does not exist";

			RemoveAlbumFiles(album);
			dbContext.Albums.Remove(album);
			await dbContext.SaveChangesAsync();

			return "Album deleted";
		}

        public async Task<AlbumDTO?> UpdateAsync(AlbumDTO albumDTO)
		{
			using var dbContext = _context.CreateDbContext();

			var album = await dbContext.Albums.Include(x => x.Songs).FirstOrDefaultAsync(a => a.Id==albumDTO.Id);
			if (album == null) return null;

            // need to think about what exactly should be updatable
            album.UploadDate=albumDTO.UploadDate;
			//album.Duration = album.Duration;
			//album.CoverImageUrl = album.CoverImageUrl;
			album.Name = albumDTO.Name;
			await dbContext.SaveChangesAsync();

			return albumDTO;
		}

		public async Task<bool> CheckIfAlbumExists(Guid albumId)
		{
			var dbContext = _context.CreateDbContext();

			return await dbContext.Albums.AnyAsync(x => x.Id == albumId);
		}

        private string UploadSong(string? songFile) //should be moved to seperate cloud helper class
        {
            //upload the song to cloud here and get its url
            return "songURL";
        }

        private string UploadCoverImage(string coverImage) //should be moved to seperate cloud helper class
        {
            //upload the cover to cloud here and get its url
            return "coverImageURL"; //return the url
        }

        private void RemoveAlbumFiles(Album album) //should be moved to seperate cloud helper class
        {
            // remove album.CoverImageUrl file from cloud
            foreach (var song in album.Songs)
            {
				RemoveSongFile(song);
            }
        }

        private void RemoveSongFile(Song song) //should be moved to seperate cloud helper class
        {
            // remove song.SongFileUrl file from cloud
        }

        private async Task<User> GetUserByUsername(string userName, AppDbContext dbContext)
        {
            var user = await dbContext.Users.Include("Albums").FirstOrDefaultAsync(x => x.Name == userName);
            return user;
        }
    }
}
