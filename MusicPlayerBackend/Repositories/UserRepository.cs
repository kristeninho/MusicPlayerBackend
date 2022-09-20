using Microsoft.EntityFrameworkCore;
using MusicPlayerBackend.Data;
using MusicPlayerBackend.Models;
using MusicPlayerBackend.Models.DTOs;
using MusicPlayerBackend.Repositories.Interfaces;
using System.Linq;

namespace MusicPlayerBackend.Repositories
{
	public class UserRepository : IUserRepository
	{
		private readonly IDbContextFactory<AppDbContext> _context;
		public UserRepository(IDbContextFactory<AppDbContext> context)
		{
			_context = context;
		}

		public async Task<UserCredentialsDTO?> AddAsync(UserCredentialsDTO userCredentialsDTO)
		{
			if (!IsUserCredentialsValid(userCredentialsDTO)) return null;
			return await AddUserToDatabaseAsync(userCredentialsDTO);
		}

		private bool IsUserCredentialsValid(UserCredentialsDTO userCredentialsDTO)
		{
			if (IsUserNameValid(userCredentialsDTO.UserName) && IsPasswordValid(userCredentialsDTO.Password)) return true;
			return false;
		}

		private bool IsPasswordValid(string password)
		{
			//password conditions: Length 6-30, atleast one symbol, number, upperchar
			if(password == null || password.Length < 6 || password.Length > 30 || !password.Any(ch => char.IsPunctuation(ch) || char.IsSymbol(ch)) ||
				 !password.Any(ch => char.IsDigit(ch)) || !password.Any(ch => char.IsUpper(ch))) return false;
			return true;
		}

		private bool IsUserNameValid(string userName)
		{
			//username conditions: Length 3-15, Only letters and numbers
			if(userName == null || userName.Length < 3 || userName.Length > 15 || userName.Any(ch => !char.IsLetterOrDigit(ch))) return false;
			return true;
		}

		private async Task<UserCredentialsDTO> AddUserToDatabaseAsync(UserCredentialsDTO userCredentialsDTO)
		{
			using var dbContext = _context.CreateDbContext();
			
			var user = new User
			{
				Name = userCredentialsDTO.UserName,
				Password = userCredentialsDTO.Password
			};
			await dbContext.Users.AddAsync(user);
			await dbContext.SaveChangesAsync();
			return userCredentialsDTO;
		}

		public async Task<string> DeleteAsync(UserCredentialsDTO userCredentialsDTO)
		{
			if (!IsUserCredentialsValid(userCredentialsDTO)) return "Invalid request";

			using var dbContext = _context.CreateDbContext();
			User? user = await GetUserByNameAsync(userCredentialsDTO, dbContext);
			if (user == null) return "User does not exist";

			dbContext.Users.Remove(user);
			await dbContext.SaveChangesAsync();
			return "User deleted";
		}

		private static async Task<User?> GetUserByNameAsync(UserCredentialsDTO userCredentialsDTO, AppDbContext dbContext)
		{
			return await dbContext.Users.FirstOrDefaultAsync(u => u.Name.ToUpper() == userCredentialsDTO.UserName.ToUpper());
		}

		public async Task<UserCredentialsDTO?> UpdateAsync(UserCredentialsDTO userCredentialsDTO)
		{
			if (!IsUserCredentialsValid(userCredentialsDTO)) return null;

			using var dbContext = _context.CreateDbContext();
			User? user = await GetUserByNameAsync(userCredentialsDTO, dbContext);
			if (user == null) return null;

			user.Password = userCredentialsDTO.Password;
			await dbContext.SaveChangesAsync();

			return userCredentialsDTO;
		}

		public async Task<UserDataDTO?> GetUserDataAsync(string userName)
		{
			if (!IsUserNameValid(userName)) return null;

			using var dbContext = _context.CreateDbContext();
			var user = await dbContext.Users.Include(u => u.Albums).ThenInclude(a => a.Songs).FirstOrDefaultAsync(u => u.Name == userName);
			UserDataDTO userDTO = TransferUserDataToDTO(user);
			return userDTO;
		}

		private UserDataDTO TransferUserDataToDTO(User? user)
		{
			List<AlbumDTO> albumDTOs = new List<AlbumDTO>();
			List<SongDTO> songDTOs = new List<SongDTO>();
			foreach (var album in user.Albums)
			{
				var albumDTO = new AlbumDTO
				{
					Id = album.Id,
					Name = album.Name,
					Duration = album.Duration,
					UploadDate = album.UploadDate,
					UserName = user.Name,
					CoverImage = album.CoverImage,
					Songs = new List<SongDTO>()
				};
				
				foreach(var song in album.Songs)
				{
					var songDTO = new SongDTO
					{
						Id = song.Id,
						Name = song.Name,
						Duration = song.Duration,
						SongFile = song.SongFile,
						UploadDate = song.UploadDate,
						AlbumId = album.Id
					};

					songDTOs.Add(songDTO);
					albumDTO.Songs.Add(songDTO);
				}
				albumDTOs.Add(albumDTO);
			}
			return new UserDataDTO
			{
				Name = user.Name,
				Albums = albumDTOs,
				Songs = songDTOs
			};
		}

		//private UserDataDTO TransferUserDataToDTO(User? user)
		//{
		//	List<SongDTO> songDTOs = TransferSongsToSongDTOs(user.Albums[0, user.Name);
		//	List<AlbumDTO> albumDTOs = TransferAlbumsToAlbumDTOs(user.Albums, songDTOs);
		//	return new UserDataDTO
		//	{
		//		Name = user.Name,
		//		Albums = albumDTOs,
		//		Songs = songDTOs
		//	};
		//}

		//private List<SongDTO> TransferSongsToSongDTOs(ICollection<Song>? songs, string userName)
		//{
		//	var songDTOs = new List<SongDTO>();
		//	foreach(var song in songs)
		//	{
		//		songDTOs.Add(
		//			new SongDTO
		//			{
		//				Id = song.Id,
		//				Name = song.Name,
		//				Duration = song.Duration,
		//				SongFile = song.SongFile,
		//				UploadDate = song.UploadDate,
		//				UserName = userName
		//			}
		//		);
		//	}
		//	return songDTOs;
		//}

		//private List<AlbumDTO> TransferAlbumsToAlbumDTOs(ICollection<Album>? albums, List<SongDTO> songDTOs)
		//{
		//	var albumDTOs = new List<AlbumDTO>();

		//	foreach(var album in albums)
		//	{
		//		albumDTOs.Add(new AlbumDTO
		//		{
		//			Id = album.Id,
		//			Name = album.Name,
		//			CoverImage = album.CoverImage,
		//			Duration = album.Duration,
		//			Songs = album.Songs.SelectMany(song => songDTOs.Where(songDTO => song.Id == songDTO.Id)).ToList(),
		//			UploadDate = album.UploadDate
		//		});
		//	}
		//	return albumDTOs;
		//}
	}
}
