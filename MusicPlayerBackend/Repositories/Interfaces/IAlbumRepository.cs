using MusicPlayerBackend.Models.DTOs;

namespace MusicPlayerBackend.Repositories.Interfaces
{
	public interface IAlbumRepository: IBaseRepository<AlbumDTO>
	{
		Task<bool> CheckIfAlbumExists(Guid albumId);
	}
}