using MusicPlayerBackend.Models.DTOs;

namespace MusicPlayerBackend.Repositories.Interfaces
{
	public interface IUserRepository: IBaseRepository<UserCredentialsDTO>
	{
		Task<UserDataDTO?> GetUserDataAsync(string userName);
		Task<bool> CheckIfUserWithSameNameAndPasswordExists(UserCredentialsDTO user);
		Task<bool> CheckIfUserWithSameNameExists(string userName);
    }
}
