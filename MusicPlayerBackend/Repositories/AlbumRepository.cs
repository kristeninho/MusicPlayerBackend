using Microsoft.EntityFrameworkCore;
using MusicPlayerBackend.Data;
using MusicPlayerBackend.Models;
using MusicPlayerBackend.Models.DTOs;
using MusicPlayerBackend.Repositories.Interfaces;

namespace MusicPlayerBackend.Repositories
{
    public class AlbumRepository : IAlbumRepository
	{
		private readonly IDbContextFactory<AppDbContext> _context;
		private readonly IAzureCloudStorageRepository _azureCloudStorage = new AzureCloudStorageRepository();
		public AlbumRepository(IDbContextFactory<AppDbContext> context)
		{
			_context = context;
		}
		public async Task<AlbumDTO?> AddAsync(AlbumDTO albumDTO)
		{
			using var dbContext = _context.CreateDbContext();

			var user = await GetUserByUsername(albumDTO.UserName, dbContext);
			if (user == null) return null;

			var coverImageNameInCloud = "";
			
			if (albumDTO.CoverImage == null) coverImageNameInCloud = "defaultCoverImage"; // some default image url;
			else
			{
				try
				{
					coverImageNameInCloud = await _azureCloudStorage.UploadFileToCloudAndReturnName(albumDTO.UserName, albumDTO.Name, "jpg", albumDTO.CoverImage, "images"); 
				}
				catch (Exception ex)
				{
					return null; //failed to upload to cloud
				}
            }

			var newAlbum = new Album
			{
				Id = albumDTO.Id,
				Name = albumDTO.Name,
				CoverImageNameInCloud = coverImageNameInCloud,
				UploadDate = albumDTO.UploadDate,
				User = user
			};

			var songList = new List<Song>();

			try 
			{
                foreach (var song in albumDTO.Songs)
                {
                    songList.Add(new Song
                    {
                        Id = song.Id,
                        Name = song.Name,
                        Album = newAlbum,
                        UploadDate = song.UploadDate,
                        SongNameInCloud = await _azureCloudStorage.UploadFileToCloudAndReturnName(albumDTO.UserName, song.Name, "mp3", song.SongFile, "songs")
                    });
                }
                newAlbum.Songs = songList;

                // mabye can use Parralellism here.
                // would need to use concurrentlist
                // maybe need ", new ParallelOptions { MaxDegreeOfParallelism = X}"
                //Parallel.ForEach(albumDTO.Songs, async song =>
                //{
                //	newAlbum.Songs.Add(new Song
                //	{
                //		Id = song.Id,
                //		Name = song.Name,
                //		Album = newAlbum,
                //		Duration = song.Duration,
                //		UploadDate = song.UploadDate,
                //		SongFileUrl = await UploadFileToCloud(albumDTO.UserName, song.Name, "mp3", song.SongFile, "songs")
                //	});
                //});

                await dbContext.AddAsync(newAlbum);
                await dbContext.SaveChangesAsync();

                return albumDTO;
            } 
			catch (Exception ex)
			{
                return null;
			}
			
		}

		public async Task<string> DeleteAsync(string albumId)
		{
			using var dbContext = _context.CreateDbContext();
			var album = await dbContext.Albums.Include(x => x.Songs).FirstOrDefaultAsync(a => a.Id == new Guid(albumId));
			if (album == null) return "Album does not exist";

			try
			{
                await RemoveAlbumFilesFromCloud(album, album.Songs);
                dbContext.Albums.Remove(album);
                await dbContext.SaveChangesAsync();

                return "Album deleted";
            }
			catch (Exception ex) 
			{
				return $"EXCEPTION: {ex}";
			}
		}

        public async Task<AlbumDTO?> UpdateAsync(AlbumDTO albumDTO)
		{
			using var dbContext = _context.CreateDbContext();

			var album = await dbContext.Albums.Include(x => x.Songs).FirstOrDefaultAsync(a => a.Id==albumDTO.Id);
			if (album == null) return null;

			var coverImageNameInCloud = "";

			if (albumDTO.CoverImage == null) coverImageNameInCloud = "defaultCoverImage";
            else
            {
                try
                {
                    if (!album.Name.Equals(albumDTO.Name)) await _azureCloudStorage.DeleteAsync(album.CoverImageNameInCloud, "images");

                    coverImageNameInCloud = await _azureCloudStorage.UploadFileToCloudAndReturnName(albumDTO.UserName, albumDTO.Name, "jpg", albumDTO.CoverImage, "images");
                }
                catch (Exception ex)
                {
                    return null;
                }
            }

            album.UploadDate = albumDTO.UploadDate;
			album.CoverImageNameInCloud = coverImageNameInCloud;
			album.Name = albumDTO.Name;
			await dbContext.SaveChangesAsync();

			return albumDTO;
		}

		public async Task<bool> CheckIfAlbumExists(Guid albumId)
		{
			var dbContext = _context.CreateDbContext();

			return await dbContext.Albums.AnyAsync(x => x.Id == albumId);
		}

        private async Task RemoveAlbumFilesFromCloud(Album album, ICollection<Song> songs)
        {
            try
            {
                // remove image
                if (album.CoverImageNameInCloud != "defaultCoverImage") await _azureCloudStorage.DeleteAsync(album.CoverImageNameInCloud, "images");

                // remove songs
                // maybe need ", new ParallelOptions { MaxDegreeOfParallelism = X}"
                Parallel.ForEach(songs, async song =>
                {
                    await _azureCloudStorage.DeleteAsync(song.SongNameInCloud, "songs");
                });

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private async Task<User> GetUserByUsername(string userName, AppDbContext dbContext)
        {
            var user = await dbContext.Users.Include("Albums").FirstOrDefaultAsync(x => x.Name == userName);
            return user;
        }
    }
}
