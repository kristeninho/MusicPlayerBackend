using Microsoft.EntityFrameworkCore;
using MusicPlayerBackend.Data;
using MusicPlayerBackend.Helpers;
using MusicPlayerBackend.Models;
using MusicPlayerBackend.Models.DTOs;
using MusicPlayerBackend.Repositories.Interfaces;
using System.Globalization;

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
		public async Task<AlbumDTO?> AddAsync(AlbumDTO entity)
		{
			// TODO: Need to add user login logic first and ask for current user here.
			// If current logged in user is same as album's user, then let it add the album.
			// Can probably read the username from JWT token

			if (!_validator.IsAlbumDTOValid(entity)) return null; //this check should be done seperately, maybe in controller

			using var dbContext = _context.CreateDbContext();

			var user = await GetUserByUsername(entity.UserName, dbContext);
			if (user == null) return null;

			var newAlbum = new Album
			{
				Id = entity.Id,
				Name = entity.Name,
				CoverImage = entity.CoverImage,
				Duration = entity.Duration,
				UploadDate = entity.UploadDate,
				User = user
			};

			newAlbum.Songs = entity.Songs.Select(s => new Song
			{
				Id = s.Id,
				SongFile = s.SongFile,
				Duration = s.Duration,
				Name = s.Name,
				UploadDate = s.UploadDate,
				Album = newAlbum
			}).ToList();

			await dbContext.AddAsync(newAlbum);
			await dbContext.SaveChangesAsync();

			return entity;
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

		public async Task<AlbumDTO?> UpdateAsync(AlbumDTO entity)
		{
			// TODO: Need to add user login logic first and ask for current user here.
			// If current logged in user is same as album's user, then let it update the album.
			// Can probably read the username from JWT token and will need to check that some info does not change
			// for example username and albumId


			// songs will not be updated here
			if (!!_validator.IsAlbumDTOValid(entity)) return null; //this check should be done seperately, maybe in controller

			using var dbContext = _context.CreateDbContext();

			var album = await dbContext.Albums.Include(x => x.Songs).FirstOrDefaultAsync(a => a.Id==entity.Id);
			if (album == null) return null;

			album.UploadDate=entity.UploadDate;
			album.CoverImage = entity.CoverImage;
			album.Name = entity.Name;
			await dbContext.SaveChangesAsync();

			return entity;
		}
	}
}
