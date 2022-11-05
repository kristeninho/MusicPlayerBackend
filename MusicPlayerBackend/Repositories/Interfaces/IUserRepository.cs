using MusicPlayerBackend.Models.DTOs;

namespace MusicPlayerBackend.Repositories.Interfaces
{
	public interface IUserRepository: IBaseRepository<UserCredentialsDTO>
	{
		Task<UserDataDTO?> GetUserDataAsync(string userName);
		Task<bool> CheckIfUserExistsByUsernameAndPassword(UserCredentialsDTO user);
		Task<bool> CheckIfUserExistsByUsername(string userName);
    }
}
