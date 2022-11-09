using Microsoft.EntityFrameworkCore;
using MusicPlayerBackend.Models.DTOs;

namespace MusicPlayerBackend.Repositories.Interfaces
{
	public interface ISongRepository: IBaseRepository<SongDTO>
	{
        Task<bool> CheckIfSongExists(Guid albumId);
    }
}
