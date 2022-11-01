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
		private readonly UserCredentialsValidator _userCredentialsValidator;
		public UserRepository(IDbContextFactory<AppDbContext> context)
		{
			_context = context;
			_userCredentialsValidator = new UserCredentialsValidator();
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

		public async Task<string> DeleteAsync(UserCredentialsDTO userCredentialsDTO)
		{
            //TODO: This user credentials validation will be removed when JWT token is ready
            if (!_userCredentialsValidator.AreUserCredentialsValid(userCredentialsDTO)) return "Invalid request";

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
			//TODO: This user credentials validation will be removed when JWT token is ready
			if (!_userCredentialsValidator.AreUserCredentialsValid(userCredentialsDTO)) return null;

			using var dbContext = _context.CreateDbContext();
			User? user = await GetUserByNameAsync(userCredentialsDTO, dbContext);
			if (user == null) return null;

			user.Password = userCredentialsDTO.Password;
			await dbContext.SaveChangesAsync();

			return userCredentialsDTO;
		}

		public async Task<UserDataDTO?> GetUserDataAsync(string userName)
		{
			if (!_userCredentialsValidator.IsUserNameValid(userName)) return null;

			using var dbContext = _context.CreateDbContext();
			var user = await dbContext.Users.Include(u => u.Albums).ThenInclude(a => a.Songs).FirstOrDefaultAsync(u => u.Name == userName);
			if (user == null) return null;
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

		public async Task<bool> CheckIfUserWithSameNameAndPasswordExists(UserCredentialsDTO user)
		{
            using var dbContext = _context.CreateDbContext();

			return await dbContext.Users.AnyAsync(x => x.Name == user.UserName && x.Password == user.Password);
        }
        public async Task<bool> CheckIfUserWithSameNameExists(string userName)
        {
            using var dbContext = _context.CreateDbContext();

            return await dbContext.Users.AnyAsync(x => x.Name == userName);
        }
    }
}
