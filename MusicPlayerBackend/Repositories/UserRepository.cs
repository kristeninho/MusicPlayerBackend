using Microsoft.EntityFrameworkCore;
using MusicPlayerBackend.Data;
using MusicPlayerBackend.Models;
using MusicPlayerBackend.Models.DTOs;
using MusicPlayerBackend.Repositories.Interfaces;
using MusicPlayerBackend.Helpers;

namespace MusicPlayerBackend.Repositories
{
	public class UserRepository : IUserRepository
	{
		private readonly IDbContextFactory<AppDbContext> _context;
		private readonly Validator _validator;
		public UserRepository(IDbContextFactory<AppDbContext> context)
		{
			_context = context;
			_validator = new Validator();
		}

		public async Task<UserCredentialsDTO?> AddAsync(UserCredentialsDTO userCredentialsDTO)
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

		public async Task<string> DeleteAsync(string userName)
		{
			using var dbContext = _context.CreateDbContext();
			User? user = await GetUserByNameAsync(userName, dbContext);
			if (user == null) return "User does not exist";

			dbContext.Users.Remove(user);
			await dbContext.SaveChangesAsync();

			return "User deleted";
		}

		private static async Task<User?> GetUserByNameAsync(string userName, AppDbContext dbContext)
		{
			return await dbContext.Users.FirstOrDefaultAsync(u => u.Name.ToUpper() == userName.ToUpper());
		}

		public async Task<UserCredentialsDTO?> UpdateAsync(UserCredentialsDTO userCredentialsDTO)
		{
			using var dbContext = _context.CreateDbContext();
			User? user = await GetUserByNameAsync(userCredentialsDTO.UserName, dbContext);
			if (user == null) return null; //maybe remove this, because user can't be null if already logged in and authorized

			user.Password = userCredentialsDTO.Password;
			await dbContext.SaveChangesAsync();

			return userCredentialsDTO;
		}

		public async Task<UserDataDTO?> GetUserDataAsync(string userName)
		{
			//if (!_userCredentialsValidator.IsUserNameValid(userName)) return null;  -- this is done in the controller

			using var dbContext = _context.CreateDbContext();
			var user = await dbContext.Users.Include(u => u.Albums).ThenInclude(a => a.Songs).FirstOrDefaultAsync(u => u.Name == userName);
			if (user == null) return null; //maybe remove this, because user can't be null if already logged in and authorized
			UserDataDTO userDTO = TransferUserDataToDTO(user);

			return userDTO;
		}

		private UserDataDTO TransferUserDataToDTO(User? user)
		{
			List<AlbumDTO> albumDTOs = new List<AlbumDTO>();
			List<SongDTO> songDTOs = new List<SongDTO>();
			// this can be done using TPL
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

		public async Task<bool> CheckIfUserExistsByUsernameAndPassword(UserCredentialsDTO user)
		{
            using var dbContext = _context.CreateDbContext();

			return await dbContext.Users.AnyAsync(x => x.Name == user.UserName && x.Password == user.Password);
        }
        public async Task<bool> CheckIfUserExistsByUsername(string userName)
        {
            using var dbContext = _context.CreateDbContext();

            return await dbContext.Users.AnyAsync(x => x.Name == userName);
        }
    }
}
