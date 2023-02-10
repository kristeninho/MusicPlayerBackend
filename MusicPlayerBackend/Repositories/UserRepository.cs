using Microsoft.EntityFrameworkCore;
using MusicPlayerBackend.Data;
using MusicPlayerBackend.Models;
using MusicPlayerBackend.Models.DTOs;
using MusicPlayerBackend.Repositories.Interfaces;
using System.Text;
using System.Security.Cryptography;

namespace MusicPlayerBackend.Repositories
{
    public class UserRepository : IUserRepository
	{
		private readonly IDbContextFactory<AppDbContext> _context;
        private readonly IAzureCloudStorageRepository _azureCloudStorage = new AzureCloudStorageRepository();

        private readonly byte[] _passwordSalt = Encoding.ASCII.GetBytes(ConfigurationManager.SecretAppSettings.GetValue<string>("PasswordSalt"));
        private readonly int _keySize = 64;
        private readonly int _iterations = 350000;
        private readonly HashAlgorithmName _hashAlgorithm = HashAlgorithmName.SHA512;

        public UserRepository(IDbContextFactory<AppDbContext> context)
		{
			_context = context;
		}

		public async Task<UserCredentialsDTO?> AddAsync(UserCredentialsDTO userCredentialsDTO)
		{
            using var dbContext = _context.CreateDbContext();

            var user = new User
            {
                Name = userCredentialsDTO.UserName,
                Password = HashPassword(userCredentialsDTO.Password)
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

			user.Password = HashPassword(userCredentialsDTO.Password);
			await dbContext.SaveChangesAsync();

			return userCredentialsDTO;
		}

		public async Task<UserDataDTO?> GetUserDataAsync(string userName)
		{
			using var dbContext = _context.CreateDbContext();
			var user = await dbContext.Users.Include(u => u.Albums).ThenInclude(a => a.Songs).FirstOrDefaultAsync(u => u.Name == userName);
			if (user == null) return null; //maybe remove this, because user can't be null if already logged in and authorized
			UserDataDTO userDTO = await TransferUserDataToDTO(user);

			return userDTO;
		}

		private async Task<UserDataDTO> TransferUserDataToDTO(User? user)
		{
			List<AlbumDTO> albumDTOs = new List<AlbumDTO>();
			List<SongDTO> songDTOs = new List<SongDTO>();
			// this can maybe be done using TPL
			try 
			{
                foreach (var album in user.Albums)
                {
                    var albumDTO = new AlbumDTO
                    {
                        Id = album.Id,
                        Name = album.Name,
                        UploadDate = album.UploadDate,
                        UserName = user.Name,
                        CoverImage = await _azureCloudStorage.DownloadFileAndReturnAsString(album.CoverImageNameInCloud, "images"),
                        Songs = new List<SongDTO>()
                    };

                    foreach (var song in album.Songs)
                    {
                        var songDTO = new SongDTO
                        {
                            Id = song.Id,
                            Name = song.Name,
                            SongFile = await _azureCloudStorage.DownloadFileAndReturnAsString(song.SongNameInCloud, "songs"),
                            UploadDate = song.UploadDate,
                            AlbumId = album.Id,
                            UserName = user.Name,
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
            catch (Exception ex)
            {
                return null;
            }
		}

		public async Task<bool> CheckIfUserExistsByUsernameAndPassword(UserCredentialsDTO user)
		{
            using var dbContext = _context.CreateDbContext();

			return await dbContext.Users.AnyAsync(x => x.Name == user.UserName && VerifyPassword(user.Password, x.Password, _passwordSalt));
        }
        public async Task<bool> CheckIfUserExistsByUsername(string userName)
        {
            using var dbContext = _context.CreateDbContext();

            return await dbContext.Users.AnyAsync(x => x.Name == userName);
        }
        private string HashPassword(string password)
        {
            var hash = Rfc2898DeriveBytes.Pbkdf2(
                Encoding.UTF8.GetBytes(password),
                _passwordSalt,
                _iterations,
                _hashAlgorithm,
                _keySize);

            return Convert.ToHexString(hash);
        }
        private bool VerifyPassword(string password, string hash, byte[] salt)
        {
            var hashToCompare = Rfc2898DeriveBytes.Pbkdf2(password, salt, _iterations, _hashAlgorithm, _keySize);
            return hashToCompare.SequenceEqual(Convert.FromHexString(hash));
        }
    }
}
