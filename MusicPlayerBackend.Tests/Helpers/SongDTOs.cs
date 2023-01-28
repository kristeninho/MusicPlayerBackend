using MusicPlayerBackend.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayerBackend.Tests.Helpers
{
	public class SongDTOs
	{
		public SongDTO GetSongDTO(string type)
		{
			var songDTO = songDTOs.First(x => x.Key == type).Value;
			return songDTO;
		}

		private Dictionary<string, SongDTO> songDTOs = new Dictionary<string, SongDTO>()
		{
			{
				"validSongDTO1",
				new SongDTO
				{
					Name = "Song1",
					Duration = "10:00",
					Id = Guid.NewGuid(),
					UploadDate = DateTime.Now,
					SongNameInCloud = "ssadasdsadasdas",
					AlbumId = Guid.Parse("5f67fd16-360c-4504-80ab-f5bb47614d90")
				}
			},
			{
				"validSongDTO2",
				new SongDTO
				{
					Name = "Song2",
					Duration = "12:00",
					Id = Guid.NewGuid(),
					UploadDate = DateTime.Now,
					SongNameInCloud = "ssadasdsadasdas",
					AlbumId = Guid.Parse("5f67fd16-360c-4504-80ab-f5bb47614d96")
				}
			},
			{
				"validSongDTO3",
				new SongDTO
				{
					Name = "Song3",
					Duration = "08:00",
					Id = Guid.NewGuid(),
					UploadDate = DateTime.Now,
					SongNameInCloud = "ssadasdsadasdas",
					AlbumId = Guid.Parse("5f67fd16-360c-4504-80ab-f5bb47614d95")
				}
			},
			{
				"validSongDTO4",
				new SongDTO
				{
					Name = "Song4",
					Duration = "08:00",
					Id = Guid.NewGuid(),
					UploadDate = DateTime.Now,
					SongNameInCloud = "ssadasdsadasdas",
					AlbumId = Guid.Parse("5f67fd16-360c-4504-80ab-f5bb47614d95")
				}
			},
			{
			"validSongDTO5",
				new SongDTO
				{
					Name = "Song4",
					Duration = "02:00",
					Id = Guid.Parse("5f67fd16-360c-4504-80ab-f5bb47614d88"),
					UploadDate = DateTime.Now,
					SongNameInCloud = "ssadasdsadasdas",
					AlbumId = Guid.Parse("5f67fd16-360c-4504-80ab-f5bb47614d93")
				}
			},
			{
			"validSongDTO6",
				new SongDTO
				{
					Name = "Song4Updated",
					Duration = "03:00",
					Id = Guid.Parse("5f67fd16-360c-4504-80ab-f5bb47614d88"),
					UploadDate = DateTime.Now,
					SongNameInCloud = "ssadasdsadasdas",
					AlbumId = Guid.Parse("5f67fd16-360c-4504-80ab-f5bb47614d93")
				}
			},
			{
			"validSongDTO7",
				new SongDTO
				{
					Name = "Song7",
					Duration = "03:00",
					Id = Guid.Parse("5f67fd16-360c-4504-80ab-f5bb47614d89"),
					UploadDate = DateTime.Now,
					SongNameInCloud = "ssadasdsadasdas",
					AlbumId = Guid.Parse("5f67fd16-360c-4504-80ab-f5bb47614d93")
				}
			}
		};
	}
}
