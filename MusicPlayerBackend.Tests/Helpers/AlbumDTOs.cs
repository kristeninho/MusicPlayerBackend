using MusicPlayerBackend.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayerBackend.Tests.Helpers
{
	public class AlbumDTOs
	{
		public AlbumDTO GetAlbumDTO(string type)
		{
			var albumDTO = albumDTOs.First(x=>x.Key==type).Value;
			return albumDTO;
		}

		private Dictionary<string, AlbumDTO> albumDTOs = new Dictionary<string, AlbumDTO>()
		{
			{"validAlbumDTO1", 
				new AlbumDTO
					{
						Id = Guid.Parse("5f67fd16-360c-4504-80ab-f5bb47614d96"),
						Name = "Album1",
						UserName = "Username1",
						Duration = "30:00",
						CoverImage = new byte[100],
						UploadDate = DateTime.Now,
						Songs = new List<SongDTO>()
						{
							new SongDTO
							{
								Name = "Song1",
								Duration = "10:00",
								Id = Guid.NewGuid(),
								UploadDate = DateTime.Now,
								SongFile = new byte[100],
								AlbumId = Guid.Parse("5f67fd16-360c-4504-80ab-f5bb47614d96")
							},
							new SongDTO
							{
								Name = "Song2",
								Duration = "12:00",
								Id = Guid.NewGuid(),
								UploadDate = DateTime.Now,
								SongFile = new byte[100],
								AlbumId = Guid.Parse("5f67fd16-360c-4504-80ab-f5bb47614d96")
							},
							new SongDTO
							{
								Name = "Song3",
								Duration = "08:00",
								Id = Guid.NewGuid(),
								UploadDate = DateTime.Now,
								SongFile = new byte[100],
								AlbumId = Guid.Parse("5f67fd16-360c-4504-80ab-f5bb47614d96")
							},
						}
					}
			},
			{"validAlbumDTO2",
				new AlbumDTO
					{
						Id = Guid.Parse("5f67fd16-360c-4504-80ab-f5bb47614d95"),
						Name = "Album2",
						UserName = "Username2",
						Duration = "30:00",
						CoverImage = new byte[100],
						UploadDate = DateTime.Now,
						Songs = new List<SongDTO>()
						{
							new SongDTO
							{
								Name = "Song1",
								Duration = "10:00",
								Id = Guid.NewGuid(),
								UploadDate = DateTime.Now,
								SongFile = new byte[100],
								AlbumId = Guid.Parse("5f67fd16-360c-4504-80ab-f5bb47614d95")
							},
							new SongDTO
							{
								Name = "Song2",
								Duration = "12:00",
								Id = Guid.NewGuid(),
								UploadDate = DateTime.Now,
								SongFile = new byte[100],
								AlbumId = Guid.Parse("5f67fd16-360c-4504-80ab-f5bb47614d95")
							},
							new SongDTO
							{
								Name = "Song3",
								Duration = "08:00",
								Id = Guid.NewGuid(),
								UploadDate = DateTime.Now,
								SongFile = new byte[100],
								AlbumId = Guid.Parse("5f67fd16-360c-4504-80ab-f5bb47614d95")
							},
						}
					}
			},
			{"validAlbumDTO3",
				new AlbumDTO
					{
						Id = Guid.Parse("5f67fd16-360c-4504-80ab-f5bb47614d94"),
						Name = "Album3",
						UserName = "Username3",
						Duration = "30:00",
						CoverImage = new byte[100],
						UploadDate = DateTime.Now,
						Songs = new List<SongDTO>()
						{
							new SongDTO
							{
								Name = "Song1",
								Duration = "10:00",
								Id = Guid.NewGuid(),
								UploadDate = DateTime.Now,
								SongFile = new byte[100],
								AlbumId = Guid.Parse("5f67fd16-360c-4504-80ab-f5bb47614d94")
							},
							new SongDTO
							{
								Name = "Song2",
								Duration = "12:00",
								Id = Guid.NewGuid(),
								UploadDate = DateTime.Now,
								SongFile = new byte[100],
								AlbumId = Guid.Parse("5f67fd16-360c-4504-80ab-f5bb47614d94")
							},
							new SongDTO
							{
								Name = "Song3",
								Duration = "08:00",
								Id = Guid.NewGuid(),
								UploadDate = DateTime.Now,
								SongFile = new byte[100],
								AlbumId = Guid.Parse("5f67fd16-360c-4504-80ab-f5bb47614d94")
							},
						}
					}
			},
			{"validAlbumDTO4",
				new AlbumDTO
					{
						Id = Guid.Parse("5f67fd16-360c-4504-80ab-f5bb47614d93"),
						Name = "Album3",
						UserName = "Username4",
						Duration = "30:00",
						CoverImage = new byte[100],
						UploadDate = DateTime.Now,
						Songs = new List<SongDTO>()
						{
							new SongDTO
							{
								Name = "Song1",
								Duration = "10:00",
								Id = Guid.NewGuid(),
								UploadDate = DateTime.Now,
								SongFile = new byte[100],
								AlbumId = Guid.Parse("5f67fd16-360c-4504-80ab-f5bb47614d93")
							},
							new SongDTO
							{
								Name = "Song2",
								Duration = "12:00",
								Id = Guid.NewGuid(),
								UploadDate = DateTime.Now,
								SongFile = new byte[100],
								AlbumId = Guid.Parse("5f67fd16-360c-4504-80ab-f5bb47614d93")
							},
							new SongDTO
							{
								Name = "Song3",
								Duration = "08:00",
								Id = Guid.NewGuid(),
								UploadDate = DateTime.Now,
								SongFile = new byte[100],
								AlbumId = Guid.Parse("5f67fd16-360c-4504-80ab-f5bb47614d93")
							},
						}
					}
			},
			{"validAlbumDTO5",
				new AlbumDTO
					{
						Id = Guid.Parse("5f67fd16-360c-4504-80ab-f5bb47614d93"),
						Name = "Album4",
						UserName = "Username4",
						Duration = "30:00",
						CoverImage = new byte[100],
						UploadDate = DateTime.Now,
						Songs = new List<SongDTO>()
						{
							new SongDTO
							{
								Name = "Song1",
								Duration = "10:00",
								Id = Guid.NewGuid(),
								UploadDate = DateTime.Now,
								SongFile = new byte[100],
								AlbumId = Guid.Parse("5f67fd16-360c-4504-80ab-f5bb47614d93")
							},
							new SongDTO
							{
								Name = "Song2",
								Duration = "12:00",
								Id = Guid.NewGuid(),
								UploadDate = DateTime.Now,
								SongFile = new byte[100],
								AlbumId = Guid.Parse("5f67fd16-360c-4504-80ab-f5bb47614d93")
							},
							new SongDTO
							{
								Name = "Song3",
								Duration = "08:00",
								Id = Guid.NewGuid(),
								UploadDate = DateTime.Now,
								SongFile = new byte[100],
								AlbumId = Guid.Parse("5f67fd16-360c-4504-80ab-f5bb47614d93")
							}
						}
					}
			},
			{"validAlbumDTO6",
				new AlbumDTO
					{
						Id = Guid.Parse("5f67fd16-360c-4504-80ab-f5bb47614d92"),
						Name = "Album4",
						UserName = "Username6",
						Duration = "30:00",
						CoverImage = new byte[100],
						UploadDate = DateTime.Now,
						Songs = new List<SongDTO>()
						{
							new SongDTO
							{
								Name = "Song1",
								Duration = "10:00",
								Id = Guid.NewGuid(),
								UploadDate = DateTime.Now,
								SongFile = new byte[100],
								AlbumId = Guid.Parse("5f67fd16-360c-4504-80ab-f5bb47614d92")
							},
							new SongDTO
							{
								Name = "Song2",
								Duration = "12:00",
								Id = Guid.NewGuid(),
								UploadDate = DateTime.Now,
								SongFile = new byte[100],
								AlbumId = Guid.Parse("5f67fd16-360c-4504-80ab-f5bb47614d92")
							},
							new SongDTO
							{
								Name = "Song3",
								Duration = "08:00",
								Id = Guid.NewGuid(),
								UploadDate = DateTime.Now,
								SongFile = new byte[100],
								AlbumId = Guid.Parse("5f67fd16-360c-4504-80ab-f5bb47614d92")
							}
						}
					}
			},
			{"Null", new AlbumDTO{}},
			{"CoverImageNull", 
				new AlbumDTO
				{
					Id = Guid.Parse("5f67fd16-360c-4504-80ab-f5bb47614d96"),
					Name = "Album1",
					UserName = "Username1",
					Duration = "30:00",
					UploadDate = DateTime.Now,
					Songs = new List<SongDTO>()
					{
						new SongDTO
						{
							Name = "Song1",
							Duration = "10:00",
							Id = Guid.NewGuid(),
							UploadDate = DateTime.Now,
							SongFile = new byte[100],
							AlbumId = Guid.Parse("5f67fd16-360c-4504-80ab-f5bb47614d96")
						},
						new SongDTO
						{
							Name = "Song2",
							Duration = "12:00",
							Id = Guid.NewGuid(),
							UploadDate = DateTime.Now,
							SongFile = new byte[100],
							AlbumId = Guid.Parse("5f67fd16-360c-4504-80ab-f5bb47614d96")
						},
						new SongDTO
						{
							Name = "Song3",
							Duration = "08:00",
							Id = Guid.NewGuid(),
							UploadDate = DateTime.Now,
							SongFile = new byte[100],
							AlbumId = Guid.Parse("5f67fd16-360c-4504-80ab-f5bb47614d96")
						},
					}
				}
			},
			{"InvalidId", 
				new AlbumDTO
					{
						Id = Guid.Parse("00000000-0000-0000-0000-000000000000"),
						Name = "Album1",
						UserName = "Username1",
						Duration = "30:00",
						CoverImage = new byte[100],
						UploadDate = DateTime.Now,
						Songs = new List<SongDTO>()
						{
							new SongDTO
							{
								Name = "Song1",
								Duration = "10:00",
								Id = Guid.NewGuid(),
								UploadDate = DateTime.Now,
								SongFile = new byte[100],
								AlbumId = Guid.Parse("00000000-0000-0000-0000-000000000000")
							},
							new SongDTO
							{
								Name = "Song2",
								Duration = "12:00",
								Id = Guid.NewGuid(),
								UploadDate = DateTime.Now,
								SongFile = new byte[100],
								AlbumId = Guid.Parse("00000000-0000-0000-0000-000000000000")
							},
							new SongDTO
							{
								Name = "Song3",
								Duration = "08:00",
								Id = Guid.NewGuid(),
								UploadDate = DateTime.Now,
								SongFile = new byte[100],
								AlbumId = Guid.Parse("00000000-0000-0000-0000-000000000000")
							},
						}
					}
			},
			{"UsernameNull",
				new AlbumDTO
					{
						Id = Guid.Parse("5f67fd16-360c-4504-80ab-f5bb47614d96"),
						Name = "Album1",
						UserName = null,
						Duration = "30:00",
						CoverImage = new byte[100],
						UploadDate = DateTime.Now,
						Songs = new List<SongDTO>()
						{
							new SongDTO
							{
								Name = "Song1",
								Duration = "10:00",
								Id = Guid.NewGuid(),
								UploadDate = DateTime.Now,
								SongFile = new byte[100],
								AlbumId = Guid.Parse("5f67fd16-360c-4504-80ab-f5bb47614d96")
							},
							new SongDTO
							{
								Name = "Song2",
								Duration = "12:00",
								Id = Guid.NewGuid(),
								UploadDate = DateTime.Now,
								SongFile = new byte[100],
								AlbumId = Guid.Parse("5f67fd16-360c-4504-80ab-f5bb47614d96")
							},
							new SongDTO
							{
								Name = "Song3",
								Duration = "08:00",
								Id = Guid.NewGuid(),
								UploadDate = DateTime.Now,
								SongFile = new byte[100],
								AlbumId = Guid.Parse("5f67fd16-360c-4504-80ab-f5bb47614d96")
							},
						}
					}
			},
			{"UsernameTooShort",
				new AlbumDTO
					{
						Id = Guid.Parse("5f67fd16-360c-4504-80ab-f5bb47614d96"),
						Name = "Album1",
						UserName = "Us",
						Duration = "30:00",
						CoverImage = new byte[100],
						UploadDate = DateTime.Now,
						Songs = new List<SongDTO>()
						{
							new SongDTO
							{
								Name = "Song1",
								Duration = "10:00",
								Id = Guid.NewGuid(),
								UploadDate = DateTime.Now,
								SongFile = new byte[100],
								AlbumId = Guid.Parse("5f67fd16-360c-4504-80ab-f5bb47614d96")
							},
							new SongDTO
							{
								Name = "Song2",
								Duration = "12:00",
								Id = Guid.NewGuid(),
								UploadDate = DateTime.Now,
								SongFile = new byte[100],
								AlbumId = Guid.Parse("5f67fd16-360c-4504-80ab-f5bb47614d96")
							},
							new SongDTO
							{
								Name = "Song3",
								Duration = "08:00",
								Id = Guid.NewGuid(),
								UploadDate = DateTime.Now,
								SongFile = new byte[100],
								AlbumId = Guid.Parse("5f67fd16-360c-4504-80ab-f5bb47614d96")
							},
						}
					}
			},
			{"UsernameTooLong",
				new AlbumDTO
					{
						Id = Guid.Parse("5f67fd16-360c-4504-80ab-f5bb47614d96"),
						Name = "Album1",
						UserName = "Username1Username1",
						Duration = "30:00",
						CoverImage = new byte[100],
						UploadDate = DateTime.Now,
						Songs = new List<SongDTO>()
						{
							new SongDTO
							{
								Name = "Song1",
								Duration = "10:00",
								Id = Guid.NewGuid(),
								UploadDate = DateTime.Now,
								SongFile = new byte[100],
								AlbumId = Guid.Parse("5f67fd16-360c-4504-80ab-f5bb47614d96")
							},
							new SongDTO
							{
								Name = "Song2",
								Duration = "12:00",
								Id = Guid.NewGuid(),
								UploadDate = DateTime.Now,
								SongFile = new byte[100],
								AlbumId = Guid.Parse("5f67fd16-360c-4504-80ab-f5bb47614d96")
							},
							new SongDTO
							{
								Name = "Song3",
								Duration = "08:00",
								Id = Guid.NewGuid(),
								UploadDate = DateTime.Now,
								SongFile = new byte[100],
								AlbumId = Guid.Parse("5f67fd16-360c-4504-80ab-f5bb47614d96")
							},
						}
					}
			},
			{"UsernameHasSymbols",
				new AlbumDTO
					{
						Id = Guid.Parse("5f67fd16-360c-4504-80ab-f5bb47614d96"),
						Name = "Album1",
						UserName = "Username1!",
						Duration = "30:00",
						CoverImage = new byte[100],
						UploadDate = DateTime.Now,
						Songs = new List<SongDTO>()
						{
							new SongDTO
							{
								Name = "Song1",
								Duration = "10:00",
								Id = Guid.NewGuid(),
								UploadDate = DateTime.Now,
								SongFile = new byte[100],
								AlbumId = Guid.Parse("5f67fd16-360c-4504-80ab-f5bb47614d96")
							},
							new SongDTO
							{
								Name = "Song2",
								Duration = "12:00",
								Id = Guid.NewGuid(),
								UploadDate = DateTime.Now,
								SongFile = new byte[100],
								AlbumId = Guid.Parse("5f67fd16-360c-4504-80ab-f5bb47614d96")
							},
							new SongDTO
							{
								Name = "Song3",
								Duration = "08:00",
								Id = Guid.NewGuid(),
								UploadDate = DateTime.Now,
								SongFile = new byte[100],
								AlbumId = Guid.Parse("5f67fd16-360c-4504-80ab-f5bb47614d96")
							},
						}
					}
			},
			{"InvalidDuration",
				new AlbumDTO
					{
						Id = Guid.Parse("5f67fd16-360c-4504-80ab-f5bb47614d96"),
						Name = "Album1",
						UserName = "Username1",
						Duration = "30",
						CoverImage = new byte[100],
						UploadDate = DateTime.Now,
						Songs = new List<SongDTO>()
						{
							new SongDTO
							{
								Name = "Song1",
								Duration = "10:00",
								Id = Guid.NewGuid(),
								UploadDate = DateTime.Now,
								SongFile = new byte[100],
								AlbumId = Guid.Parse("5f67fd16-360c-4504-80ab-f5bb47614d96")
							},
							new SongDTO
							{
								Name = "Song2",
								Duration = "12:00",
								Id = Guid.NewGuid(),
								UploadDate = DateTime.Now,
								SongFile = new byte[100],
								AlbumId = Guid.Parse("5f67fd16-360c-4504-80ab-f5bb47614d96")
							},
							new SongDTO
							{
								Name = "Song3",
								Duration = "08:00",
								Id = Guid.NewGuid(),
								UploadDate = DateTime.Now,
								SongFile = new byte[100],
								AlbumId = Guid.Parse("5f67fd16-360c-4504-80ab-f5bb47614d96")
							},
						}
					}
			},
			{"InvalidSongCount",
				new AlbumDTO
					{
						Id = Guid.Parse("5f67fd16-360c-4504-80ab-f5bb47614d96"),
						Name = "Album1",
						UserName = "Username1",
						Duration = "30:00",
						CoverImage = new byte[100],
						UploadDate = DateTime.Now,
						Songs = new List<SongDTO>()
					}
			},
			{"AlbumNameNull",
				new AlbumDTO
					{
						Id = Guid.Parse("5f67fd16-360c-4504-80ab-f5bb47614d96"),
						UserName = "Username1",
						Duration = "30:00",
						CoverImage = new byte[100],
						UploadDate = DateTime.Now,
						Songs = new List<SongDTO>()
						{
							new SongDTO
							{
								Name = "Song1",
								Duration = "10:00",
								Id = Guid.NewGuid(),
								UploadDate = DateTime.Now,
								SongFile = new byte[100],
								AlbumId = Guid.Parse("5f67fd16-360c-4504-80ab-f5bb47614d96")
							},
							new SongDTO
							{
								Name = "Song2",
								Duration = "12:00",
								Id = Guid.NewGuid(),
								UploadDate = DateTime.Now,
								SongFile = new byte[100],
								AlbumId = Guid.Parse("5f67fd16-360c-4504-80ab-f5bb47614d96")
							},
							new SongDTO
							{
								Name = "Song3",
								Duration = "08:00",
								Id = Guid.NewGuid(),
								UploadDate = DateTime.Now,
								SongFile = new byte[100],
								AlbumId = Guid.Parse("5f67fd16-360c-4504-80ab-f5bb47614d96")
							},
						}
					}
			},
			{"AlbumNameEmpty",
				new AlbumDTO
					{
						Id = Guid.Parse("5f67fd16-360c-4504-80ab-f5bb47614d96"),
						UserName = "Username1",
						Duration = "30:00",
						Name = "",
						CoverImage = new byte[100],
						UploadDate = DateTime.Now,
						Songs = new List<SongDTO>()
						{
							new SongDTO
							{
								Name = "Song1",
								Duration = "10:00",
								Id = Guid.NewGuid(),
								UploadDate = DateTime.Now,
								SongFile = new byte[100],
								AlbumId = Guid.Parse("5f67fd16-360c-4504-80ab-f5bb47614d96")
							},
							new SongDTO
							{
								Name = "Song2",
								Duration = "12:00",
								Id = Guid.NewGuid(),
								UploadDate = DateTime.Now,
								SongFile = new byte[100],
								AlbumId = Guid.Parse("5f67fd16-360c-4504-80ab-f5bb47614d96")
							},
							new SongDTO
							{
								Name = "Song3",
								Duration = "08:00",
								Id = Guid.NewGuid(),
								UploadDate = DateTime.Now,
								SongFile = new byte[100],
								AlbumId = Guid.Parse("5f67fd16-360c-4504-80ab-f5bb47614d96")
							},
						}
					}
			},
			{"UploadDateInFuture",
				new AlbumDTO
					{
						Id = Guid.Parse("5f67fd16-360c-4504-80ab-f5bb47614d96"),
						UserName = "Username1",
						Duration = "30:00",
						Name = "Album1",
						CoverImage = new byte[100],
						UploadDate = DateTime.Now.AddDays(1),
						Songs = new List<SongDTO>()
						{
							new SongDTO
							{
								Name = "Song1",
								Duration = "10:00",
								Id = Guid.NewGuid(),
								UploadDate = DateTime.Now,
								SongFile = new byte[100],
								AlbumId = Guid.Parse("5f67fd16-360c-4504-80ab-f5bb47614d96")
							},
							new SongDTO
							{
								Name = "Song2",
								Duration = "12:00",
								Id = Guid.NewGuid(),
								UploadDate = DateTime.Now,
								SongFile = new byte[100],
								AlbumId = Guid.Parse("5f67fd16-360c-4504-80ab-f5bb47614d96")
							},
							new SongDTO
							{
								Name = "Song3",
								Duration = "08:00",
								Id = Guid.NewGuid(),
								UploadDate = DateTime.Now,
								SongFile = new byte[100],
								AlbumId = Guid.Parse("5f67fd16-360c-4504-80ab-f5bb47614d96")
							},
						}
					}
			},
			{"InvalidSongId",
				new AlbumDTO
					{
						Id = Guid.Parse("5f67fd16-360c-4504-80ab-f5bb47614d96"),
						UserName = "Username1",
						Duration = "30:00",
						Name = "Album1",
						CoverImage = new byte[100],
						UploadDate = DateTime.Now,
						Songs = new List<SongDTO>()
						{
							new SongDTO
							{
								Name = "Song1",
								Duration = "10:00",
								Id = Guid.Parse("00000000-0000-0000-0000-000000000000"),
								UploadDate = DateTime.Now,
								SongFile = new byte[100],
								AlbumId = Guid.Parse("5f67fd16-360c-4504-80ab-f5bb47614d96")
							},
							new SongDTO
							{
								Name = "Song2",
								Duration = "12:00",
								Id = Guid.Parse("00000000-0000-0000-0000-000000000000"),
								UploadDate = DateTime.Now,
								SongFile = new byte[100],
								AlbumId = Guid.Parse("5f67fd16-360c-4504-80ab-f5bb47614d96")
							},
							new SongDTO
							{
								Name = "Song3",
								Duration = "08:00",
								Id = Guid.Parse("00000000-0000-0000-0000-000000000000"),
								UploadDate = DateTime.Now,
								SongFile = new byte[100],
								AlbumId = Guid.Parse("5f67fd16-360c-4504-80ab-f5bb47614d96")
							},
						}
					}
			},
			{"InvalidSongAlbumId",
				new AlbumDTO
					{
						Id = Guid.Parse("5f67fd16-360c-4504-80ab-f5bb47614d96"),
						UserName = "Username1",
						Duration = "30:00",
						Name = "Album1",
						CoverImage = new byte[100],
						UploadDate = DateTime.Now,
						Songs = new List<SongDTO>()
						{
							new SongDTO
							{
								Name = "Song1",
								Duration = "10:00",
								Id = Guid.NewGuid(),
								UploadDate = DateTime.Now,
								SongFile = new byte[100],
								AlbumId = Guid.Parse("5f67fd16-360c-4504-80ab-f5bb47614d00")
							},
							new SongDTO
							{
								Name = "Song2",
								Duration = "12:00",
								Id = Guid.NewGuid(),
								UploadDate = DateTime.Now,
								SongFile = new byte[100],
								AlbumId = Guid.Parse("5f67fd16-360c-4504-80ab-f5bb47614d00")
							},
							new SongDTO
							{
								Name = "Song3",
								Duration = "08:00",
								Id = Guid.NewGuid(),
								UploadDate = DateTime.Now,
								SongFile = new byte[100],
								AlbumId = Guid.Parse("5f67fd16-360c-4504-80ab-f5bb47614d00")
							},
						}
					}
			},
			{"InvalidSongDuration",
				new AlbumDTO
					{
						Id = Guid.Parse("5f67fd16-360c-4504-80ab-f5bb47614d96"),
						UserName = "Username1",
						Duration = "30:00",
						Name = "Album1",
						CoverImage = new byte[100],
						UploadDate = DateTime.Now,
						Songs = new List<SongDTO>()
						{
							new SongDTO
							{
								Name = "Song1",
								Duration = "10",
								Id = Guid.NewGuid(),
								UploadDate = DateTime.Now,
								SongFile = new byte[100],
								AlbumId = Guid.Parse("5f67fd16-360c-4504-80ab-f5bb47614d96")
							},
							new SongDTO
							{
								Name = "Song2",
								Duration = "12",
								Id = Guid.NewGuid(),
								UploadDate = DateTime.Now,
								SongFile = new byte[100],
								AlbumId = Guid.Parse("5f67fd16-360c-4504-80ab-f5bb47614d96")
							},
							new SongDTO
							{
								Name = "Song3",
								Duration = "08",
								Id = Guid.NewGuid(),
								UploadDate = DateTime.Now,
								SongFile = new byte[100],
								AlbumId = Guid.Parse("5f67fd16-360c-4504-80ab-f5bb47614d96")
							},
						}
					}
			},
			{"SongFileNull",
				new AlbumDTO
					{
						Id = Guid.Parse("5f67fd16-360c-4504-80ab-f5bb47614d96"),
						UserName = "Username1",
						Duration = "30:00",
						Name = "Album1",
						CoverImage = new byte[100],
						UploadDate = DateTime.Now,
						Songs = new List<SongDTO>()
						{
							new SongDTO
							{
								Name = "Song1",
								Duration = "10:00",
								Id = Guid.NewGuid(),
								UploadDate = DateTime.Now,
								AlbumId = Guid.Parse("5f67fd16-360c-4504-80ab-f5bb47614d96")
							},
							new SongDTO
							{
								Name = "Song2",
								Duration = "12:00",
								Id = Guid.NewGuid(),
								UploadDate = DateTime.Now,
								AlbumId = Guid.Parse("5f67fd16-360c-4504-80ab-f5bb47614d96")
							},
							new SongDTO
							{
								Name = "Song3",
								Duration = "08:00",
								Id = Guid.NewGuid(),
								UploadDate = DateTime.Now,
								AlbumId = Guid.Parse("5f67fd16-360c-4504-80ab-f5bb47614d96")
							},
						}
					}
			},
			{"SongUploadDateInFuture",
				new AlbumDTO
					{
						Id = Guid.Parse("5f67fd16-360c-4504-80ab-f5bb47614d96"),
						UserName = "Username1",
						Duration = "30:00",
						Name = "Album1",
						CoverImage = new byte[100],
						UploadDate = DateTime.Now,
						Songs = new List<SongDTO>()
						{
							new SongDTO
							{
								Name = "Song1",
								Duration = "10:00",
								Id = Guid.NewGuid(),
								UploadDate = DateTime.Now.AddDays(1),
								SongFile = new byte[100],
								AlbumId = Guid.Parse("5f67fd16-360c-4504-80ab-f5bb47614d96")
							},
							new SongDTO
							{
								Name = "Song2",
								Duration = "12:00",
								Id = Guid.NewGuid(),
								UploadDate = DateTime.Now.AddDays(1),
								SongFile = new byte[100],
								AlbumId = Guid.Parse("5f67fd16-360c-4504-80ab-f5bb47614d96")
							},
							new SongDTO
							{
								Name = "Song3",
								Duration = "08:00",
								Id = Guid.NewGuid(),
								UploadDate = DateTime.Now.AddDays(1),
								SongFile = new byte[100],
								AlbumId = Guid.Parse("5f67fd16-360c-4504-80ab-f5bb47614d96")
							},
						}
					}
			},
		};
	}
}
