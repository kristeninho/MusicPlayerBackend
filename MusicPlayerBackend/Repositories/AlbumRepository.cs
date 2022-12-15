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
		private readonly Validator _validator;
		public AlbumRepository(IDbContextFactory<AppDbContext> context)
		{
			_context = context;
			_validator = new Validator();
		}
		public async Task<AlbumDTO?> AddAsync(AlbumDTO albumDTO)
		{
			using var dbContext = _context.CreateDbContext();

			var user = await GetUserByUsername(albumDTO.UserName, dbContext);
			if (user == null) return null;

			var newAlbum = new Album
			{
				Id = albumDTO.Id,
				Name = albumDTO.Name,
				CoverImageUrl = albumDTO.CoverImageUrl,
				Duration = albumDTO.Duration,
				UploadDate = albumDTO.UploadDate,
				User = user
			};

			newAlbum.Songs = albumDTO.Songs.Select(s => new Song
			{
				Id = s.Id,
				SongFileUrl = s.SongFileUrl,
				Duration = s.Duration,
				Name = s.Name,
				UploadDate = s.UploadDate,
				Album = newAlbum
			}).ToList();

			await dbContext.AddAsync(newAlbum);
			await dbContext.SaveChangesAsync();

			return albumDTO;
		}

		private async Task<User> GetUserByUsername(string userName, AppDbContext dbContext)
		{
			var user = await dbContext.Users.Include("Albums").FirstOrDefaultAsync(x => x.Name == userName);
			return user;
		}

		public async Task<string> DeleteAsync(string albumId)
		{
			// TODO: Need to add user login logic first and ask for current user here.
			// If current logged in user is same as album's user, then let it delete the album
			// Can probably read the username from JWT token, but the CURRENTUSER check will be done in Controller

			using var dbContext = _context.CreateDbContext();
			var album = await dbContext.Albums.Include(x => x.Songs).FirstOrDefaultAsync(a => a.Id == new Guid(albumId));
			if(album == null) return "Album does not exist";

			dbContext.Albums.Remove(album);
			await dbContext.SaveChangesAsync();

			return "Album deleted";
		}

		public async Task<AlbumDTO?> UpdateAsync(AlbumDTO albumDTO)
		{
			using var dbContext = _context.CreateDbContext();

			var album = await dbContext.Albums.Include(x => x.Songs).FirstOrDefaultAsync(a => a.Id==albumDTO.Id);
			if (album == null) return null;

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
	}
}
