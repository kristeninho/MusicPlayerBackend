using Microsoft.EntityFrameworkCore;
using MusicPlayerBackend.Data;
using MusicPlayerBackend.Models;
using MusicPlayerBackend.Models.DTOs;
using MusicPlayerBackend.Repositories.Interfaces;
using System.Globalization;

namespace MusicPlayerBackend.Repositories
{
	public class AlbumRepository : IAlbumRepository
	{
		private readonly IDbContextFactory<AppDbContext> _context;
		public AlbumRepository(IDbContextFactory<AppDbContext> context)
		{
			_context = context;
		}
		public async Task<AlbumDTO?> AddAsync(AlbumDTO entity)
		{
			// TODO: Need to add user login logic first and ask for current user here.
			// If current logged in user is same as album's user, then let it add the album.

			if (!IsAlbumDTOValid(entity)) return null;

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

		private bool IsAlbumDTOValid(AlbumDTO entity)
		{
			if(entity == null 
				|| entity.CoverImage == null 
				|| entity.Id.ToString() == "00000000-0000-0000-0000-000000000000"
				|| !IsUserNameValid(entity.UserName)
				|| entity.Duration.Length < 4
				|| entity.Songs.Count < 1
				|| entity.Name == null // maybe unnecessary
				|| entity.Name.Length < 1
				|| DateTime.Compare(DateTime.Now, entity.UploadDate) < 0 
				|| !AreSongDTOsValid(entity.Id, entity.Songs)
				) return false;
			return true;
		}

		private bool AreSongDTOsValid(Guid albumId, List<SongDTO> songs)
		{
			foreach(var song in songs)
			{
				if (song.Id.ToString() == "00000000-0000-0000-0000-000000000000"
					|| song.AlbumId != albumId
					|| song.Duration.Length < 4
					|| song.Name.Length < 1
					|| song.SongFile == null
					|| DateTime.Compare(DateTime.Now, song.UploadDate) < 0) return false;
			}
			return true;
		}

		private bool IsUserNameValid(string userName)
		{
			//username conditions: Length 3-15, Only letters and numbers
			if (userName == null || userName.Length < 3 || userName.Length > 15 || userName.Any(ch => !char.IsLetterOrDigit(ch))) return false;
			return true;
		}

		public Task<string> DeleteAsync(AlbumDTO entity)
		{
			// TODO: Need to add user login logic first and ask for current user here.
			// If current logged in user is same as album's user, then let it delete the album
			throw new NotImplementedException();
		}

		public Task<AlbumDTO?> UpdateAsync(AlbumDTO entity)
		{
			// TODO: Need to add user login logic first and ask for current user here.
			// If current logged in user is same as album's user, then let it update the album.
			throw new NotImplementedException();
		}
	}
}
