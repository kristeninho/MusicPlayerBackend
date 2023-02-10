using MusicPlayerBackend.Models.DTOs;

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
			{"DEMOS",
				new AlbumDTO
				{
					Id = Guid.Parse("5f67fd16-360c-4504-80ab-f5bb47614d91"),
					Name = "DEMOS",
					UserName = "Username1",
					CoverImageNameInCloud = "abc",
                    CoverImage = "lZ8j1ZN08Q8TSKH2TVjLBw==",
                    UploadDate = DateTime.Now,
					Songs = new List<SongDTO>()
				}
			},
			{"validAlbumDTO1", 
				new AlbumDTO
					{
						Id = Guid.Parse("5f67fd16-360c-4504-80ab-f5bb47614d96"),
						Name = "Album1",
						UserName = "Username1",
						CoverImageNameInCloud = "abv",
						CoverImage = "lZ8j1ZN08Q8TSKH2TVjLBw==",
						UploadDate = DateTime.Now,
						Songs = new List<SongDTO>()
						{
							new SongDTO
							{
								Name = "Song1",
								Id = Guid.NewGuid(),
								UploadDate = DateTime.Now,
								SongNameInCloud = "sadsadsadsad",
								SongFile = "GzeDWOV83idFMr+pZh8G+Q==",
								AlbumId = Guid.Parse("5f67fd16-360c-4504-80ab-f5bb47614d96"),
								UserName = "Username1"
                            },
							new SongDTO
							{
								Name = "Song2",
								Id = Guid.NewGuid(),
								UploadDate = DateTime.Now,
								SongNameInCloud = "ssadasdsadasdas",
                                SongFile = "GzeDWOV83idFMr+pZh8G+Q==",
                                AlbumId = Guid.Parse("5f67fd16-360c-4504-80ab-f5bb47614d96"),
								UserName = "Username1"
                            },
							new SongDTO
							{
								Name = "Song3",
								Id = Guid.NewGuid(),
								UploadDate = DateTime.Now,
								SongNameInCloud = "ssadasdsadasdas",
                                SongFile = "GzeDWOV83idFMr+pZh8G+Q==",
                                AlbumId = Guid.Parse("5f67fd16-360c-4504-80ab-f5bb47614d96"),
                                UserName = "Username1"
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
						CoverImageNameInCloud = "abc",
                        CoverImage = "lZ8j1ZN08Q8TSKH2TVjLBw==",
                        UploadDate = DateTime.Now,
						Songs = new List<SongDTO>()
						{
							new SongDTO
							{
								Name = "Song1",
								Id = Guid.NewGuid(),
								UploadDate = DateTime.Now,
								SongNameInCloud = "ssadasdsadasdas",
                                SongFile = "GzeDWOV83idFMr+pZh8G+Q==",
                                AlbumId = Guid.Parse("5f67fd16-360c-4504-80ab-f5bb47614d95"),
                                UserName = "Username2"
                            },
							new SongDTO
							{
								Name = "Song2",
								Id = Guid.NewGuid(),
								UploadDate = DateTime.Now,
								SongNameInCloud = "ssadasdsadasdas",
                                SongFile = "GzeDWOV83idFMr+pZh8G+Q==",
                                AlbumId = Guid.Parse("5f67fd16-360c-4504-80ab-f5bb47614d95"),
                                UserName = "Username2"
                            },
							new SongDTO
							{
								Name = "Song3",
								Id = Guid.NewGuid(),
								UploadDate = DateTime.Now,
								SongNameInCloud = "ssadasdsadasdas",
                                SongFile = "GzeDWOV83idFMr+pZh8G+Q==",
                                AlbumId = Guid.Parse("5f67fd16-360c-4504-80ab-f5bb47614d95"),
                                UserName = "Username2"
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
						CoverImageNameInCloud = "ssadasdsadasdas",
						CoverImage = "lZ8j1ZN08Q8TSKH2TVjLBw==",
						UploadDate = DateTime.Now,
						Songs = new List<SongDTO>()
						{
							new SongDTO
							{
								Name = "Song1",
								Id = Guid.NewGuid(),
								UploadDate = DateTime.Now,
								SongNameInCloud = "ssadasdsadasdas",
                                SongFile = "GzeDWOV83idFMr+pZh8G+Q==",
                                AlbumId = Guid.Parse("5f67fd16-360c-4504-80ab-f5bb47614d94"),
                                UserName = "Username3"
                            },
							new SongDTO
							{
								Name = "Song2",
								Id = Guid.NewGuid(),
								UploadDate = DateTime.Now,
								SongNameInCloud = "ssadasdsadasdas",
                                SongFile = "GzeDWOV83idFMr+pZh8G+Q==",
                                AlbumId = Guid.Parse("5f67fd16-360c-4504-80ab-f5bb47614d94"),
                                UserName = "Username3"
                            },
							new SongDTO
							{
								Name = "Song3",
								Id = Guid.NewGuid(),
								UploadDate = DateTime.Now,
								SongNameInCloud = "ssadasdsadasdas",
                                SongFile = "GzeDWOV83idFMr+pZh8G+Q==",
                                AlbumId = Guid.Parse("5f67fd16-360c-4504-80ab-f5bb47614d94"),
                                UserName = "Username3"
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
						CoverImageNameInCloud = "ssadasdsadasdas",
                        CoverImage = "lZ8j1ZN08Q8TSKH2TVjLBw==",
                        UploadDate = DateTime.Now,
						Songs = new List<SongDTO>()
						{
							new SongDTO
							{
								Name = "Song1",
								Id = Guid.NewGuid(),
								UploadDate = DateTime.Now,
								SongNameInCloud = "ssadasdsadasdas",
                                SongFile = "GzeDWOV83idFMr+pZh8G+Q==",
                                AlbumId = Guid.Parse("5f67fd16-360c-4504-80ab-f5bb47614d93"),
                                UserName = "Username4"
                            },
							new SongDTO
							{
								Name = "Song2",
								Id = Guid.NewGuid(),
								UploadDate = DateTime.Now,
								SongNameInCloud = "ssadasdsadasdas",
                                SongFile = "GzeDWOV83idFMr+pZh8G+Q==",
                                AlbumId = Guid.Parse("5f67fd16-360c-4504-80ab-f5bb47614d93"),
                                UserName = "Username4"
                            },
							new SongDTO
							{
								Name = "Song3",
								Id = Guid.NewGuid(),
								UploadDate = DateTime.Now,
								SongNameInCloud = "ssadasdsadasdas",
                                SongFile = "GzeDWOV83idFMr+pZh8G+Q==",
                                AlbumId = Guid.Parse("5f67fd16-360c-4504-80ab-f5bb47614d93"),
                                UserName = "Username4"
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
						CoverImageNameInCloud = "ssadasdsadasdas",
                        CoverImage = "lZ8j1ZN08Q8TSKH2TVjLBw==",
                        UploadDate = DateTime.Now,
						Songs = new List<SongDTO>()
						{
							new SongDTO
							{
								Name = "Song1",
								Id = Guid.NewGuid(),
								UploadDate = DateTime.Now,
								SongNameInCloud = "ssadasdsadasdas",
                                SongFile = "GzeDWOV83idFMr+pZh8G+Q==",
                                AlbumId = Guid.Parse("5f67fd16-360c-4504-80ab-f5bb47614d93"),
                                UserName = "Username4"
                            },
							new SongDTO
							{
								Name = "Song2",
								Id = Guid.NewGuid(),
								UploadDate = DateTime.Now,
								SongNameInCloud = "ssadasdsadasdas",
                                SongFile = "GzeDWOV83idFMr+pZh8G+Q==",
                                AlbumId = Guid.Parse("5f67fd16-360c-4504-80ab-f5bb47614d93"),
                                UserName = "Username4"
                            },
							new SongDTO
							{
								Name = "Song3",
								Id = Guid.NewGuid(),
								UploadDate = DateTime.Now,
								SongNameInCloud = "ssadasdsadasdas",
                                SongFile = "GzeDWOV83idFMr+pZh8G+Q==",
                                AlbumId = Guid.Parse("5f67fd16-360c-4504-80ab-f5bb47614d93"),
                                UserName = "Username4"
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
						CoverImageNameInCloud = "ssadasdsadasdas",
                        CoverImage = "lZ8j1ZN08Q8TSKH2TVjLBw==",
                        UploadDate = DateTime.Now,
						Songs = new List<SongDTO>()
						{
							new SongDTO
							{
								Name = "Song1",
								Id = Guid.NewGuid(),
								UploadDate = DateTime.Now,
								SongNameInCloud = "ssadasdsadasdas",
                                SongFile = "GzeDWOV83idFMr+pZh8G+Q==",
                                AlbumId = Guid.Parse("5f67fd16-360c-4504-80ab-f5bb47614d92"),
                                UserName = "Username6"
                            },
							new SongDTO
							{
								Name = "Song2",
								Id = Guid.NewGuid(),
								UploadDate = DateTime.Now,
								SongNameInCloud = "ssadasdsadasdas",
                                SongFile = "GzeDWOV83idFMr+pZh8G+Q==",
                                AlbumId = Guid.Parse("5f67fd16-360c-4504-80ab-f5bb47614d92"),
                                UserName = "Username6"
                            },
							new SongDTO
							{
								Name = "Song3",
								Id = Guid.NewGuid(),
								UploadDate = DateTime.Now,
								SongNameInCloud = "ssadasdsadasdas",
                                SongFile = "GzeDWOV83idFMr+pZh8G+Q==",
                                AlbumId = Guid.Parse("5f67fd16-360c-4504-80ab-f5bb47614d92"),
                                UserName = "Username6"
                            }
						}
					}
			},
			{"validAlbumDTO7",
				new AlbumDTO
					{
						Id = Guid.Parse("5f67fd16-360c-4504-80ab-f5bb47614d12"),
						Name = "Album4",
						UserName = "Username7",
						CoverImageNameInCloud = "ssadasdsadasdas",
						CoverImage = "lZ8j1ZN08Q8TSKH2TVjLBw==",
						UploadDate = DateTime.Now,
						Songs = new List<SongDTO>()
						{
							new SongDTO
							{
								Name = "Song1",
								Id = Guid.NewGuid(),
								UploadDate = DateTime.Now,
								SongNameInCloud = "ssadasdsadasdas",
                                SongFile = "GzeDWOV83idFMr+pZh8G+Q==",
                                AlbumId = Guid.Parse("5f67fd16-360c-4504-80ab-f5bb47614d12"),
                                UserName = "Username7"
                            },
							new SongDTO
							{
								Name = "Song2",
								Id = Guid.NewGuid(),
								UploadDate = DateTime.Now,
								SongNameInCloud = "ssadasdsadasdas",
                                SongFile = "GzeDWOV83idFMr+pZh8G+Q==",
                                AlbumId = Guid.Parse("5f67fd16-360c-4504-80ab-f5bb47614d12"),
                                UserName = "Username7"
                            },
							new SongDTO
							{
								Name = "Song3",
								Id = Guid.NewGuid(),
								UploadDate = DateTime.Now,
								SongNameInCloud = "ssadasdsadasdas",
                                SongFile = "GzeDWOV83idFMr+pZh8G+Q==",
                                AlbumId = Guid.Parse("5f67fd16-360c-4504-80ab-f5bb47614d12"),
                                UserName = "Username7"
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
					UploadDate = DateTime.Now,
					Songs = new List<SongDTO>()
					{
						new SongDTO
						{
							Name = "Song1",
							Id = Guid.NewGuid(),
							UploadDate = DateTime.Now,
							SongNameInCloud = "ssadasdsadasdas",
							AlbumId = Guid.Parse("5f67fd16-360c-4504-80ab-f5bb47614d96"),
                            UserName = "Username1"
                        },
						new SongDTO
						{
							Name = "Song2",
							Id = Guid.NewGuid(),
							UploadDate = DateTime.Now,
							SongNameInCloud = "ssadasdsadasdas",
							AlbumId = Guid.Parse("5f67fd16-360c-4504-80ab-f5bb47614d96"),
                            UserName = "Username1"
                        },
						new SongDTO
						{
							Name = "Song3",
							Id = Guid.NewGuid(),
							UploadDate = DateTime.Now,
							SongNameInCloud ="ssadasdsadasdas",
							AlbumId = Guid.Parse("5f67fd16-360c-4504-80ab-f5bb47614d96"),
                            UserName = "Username1"
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
						CoverImageNameInCloud = "ssadasdsadasdas",
						UploadDate = DateTime.Now,
						Songs = new List<SongDTO>()
						{
							new SongDTO
							{
								Name = "Song1",
								Id = Guid.NewGuid(),
								UploadDate = DateTime.Now,
								SongNameInCloud = "ssadasdsadasdas",
								AlbumId = Guid.Parse("00000000-0000-0000-0000-000000000000"),
								UserName = "Username1"
                            },
							new SongDTO
							{
								Name = "Song2",
								Id = Guid.NewGuid(),
								UploadDate = DateTime.Now,
								SongNameInCloud = "ssadasdsadasdas",
								AlbumId = Guid.Parse("00000000-0000-0000-0000-000000000000"),
								UserName = "Username1"
                            },
							new SongDTO
							{
								Name = "Song3",
								Id = Guid.NewGuid(),
								UploadDate = DateTime.Now,
								SongNameInCloud = "ssadasdsadasdas",
								AlbumId = Guid.Parse("00000000-0000-0000-0000-000000000000"),
								UserName = "Username1"
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
						CoverImageNameInCloud = "ssadasdsadasdas",
						UploadDate = DateTime.Now,
						Songs = new List<SongDTO>()
						{
							new SongDTO
							{
								Name = "Song1",
								Id = Guid.NewGuid(),
								UploadDate = DateTime.Now,
								SongNameInCloud = "ssadasdsadasdas",
								AlbumId = Guid.Parse("5f67fd16-360c-4504-80ab-f5bb47614d96")
							},
							new SongDTO
							{
								Name = "Song2",
								Id = Guid.NewGuid(),
								UploadDate = DateTime.Now,
								SongNameInCloud = "ssadasdsadasdas",
								AlbumId = Guid.Parse("5f67fd16-360c-4504-80ab-f5bb47614d96")
							},
							new SongDTO
							{
								Name = "Song3",
								Id = Guid.NewGuid(),
								UploadDate = DateTime.Now,
								SongNameInCloud = "ssadasdsadasdas",
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
						CoverImageNameInCloud = "ssadasdsadasdas",
						UploadDate = DateTime.Now,
						Songs = new List<SongDTO>()
						{
							new SongDTO
							{
								Name = "Song1",
								Id = Guid.NewGuid(),
								UploadDate = DateTime.Now,
								SongNameInCloud = "ssadasdsadasdas",
								AlbumId = Guid.Parse("5f67fd16-360c-4504-80ab-f5bb47614d96")
							},
							new SongDTO
							{
								Name = "Song2",
								Id = Guid.NewGuid(),
								UploadDate = DateTime.Now,
								SongNameInCloud = "ssadasdsadasdas",
								AlbumId = Guid.Parse("5f67fd16-360c-4504-80ab-f5bb47614d96")
							},
							new SongDTO
							{
								Name = "Song3",
								Id = Guid.NewGuid(),
								UploadDate = DateTime.Now,
								SongNameInCloud = "ssadasdsadasdas",
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
						CoverImageNameInCloud = "ssadasdsadasdas",
						UploadDate = DateTime.Now,
						Songs = new List<SongDTO>()
						{
							new SongDTO
							{
								Name = "Song1",
								Id = Guid.NewGuid(),
								UploadDate = DateTime.Now,
								SongNameInCloud = "ssadasdsadasdas",
								AlbumId = Guid.Parse("5f67fd16-360c-4504-80ab-f5bb47614d96")
							},
							new SongDTO
							{
								Name = "Song2",
								Id = Guid.NewGuid(),
								UploadDate = DateTime.Now,
								SongNameInCloud = "ssadasdsadasdas",
								AlbumId = Guid.Parse("5f67fd16-360c-4504-80ab-f5bb47614d96")
							},
							new SongDTO
							{
								Name = "Song3",
								Id = Guid.NewGuid(),
								UploadDate = DateTime.Now,
								SongNameInCloud = "ssadasdsadasdas",
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
						CoverImageNameInCloud = "ssadasdsadasdas",
						UploadDate = DateTime.Now,
						Songs = new List<SongDTO>()
						{
							new SongDTO
							{
								Name = "Song1",
								Id = Guid.NewGuid(),
								UploadDate = DateTime.Now,
								SongNameInCloud = "ssadasdsadasdas",
								AlbumId = Guid.Parse("5f67fd16-360c-4504-80ab-f5bb47614d96")
							},
							new SongDTO
							{
								Name = "Song2",
								Id = Guid.NewGuid(),
								UploadDate = DateTime.Now,
								SongNameInCloud = "ssadasdsadasdas",
								AlbumId = Guid.Parse("5f67fd16-360c-4504-80ab-f5bb47614d96")
							},
							new SongDTO
							{
								Name = "Song3",
								Id = Guid.NewGuid(),
								UploadDate = DateTime.Now,
								SongNameInCloud = "ssadasdsadasdas",
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
						CoverImageNameInCloud = "ssadasdsadasdas",
						UploadDate = DateTime.Now,
						Songs = new List<SongDTO>()
						{
							new SongDTO
							{
								Name = "Song1",
								Id = Guid.NewGuid(),
								UploadDate = DateTime.Now,
								SongNameInCloud = "ssadasdsadasdas",
								AlbumId = Guid.Parse("5f67fd16-360c-4504-80ab-f5bb47614d96")
							},
							new SongDTO
							{
								Name = "Song2",
								Id = Guid.NewGuid(),
								UploadDate = DateTime.Now,
								SongNameInCloud = "ssadasdsadasdas",
								AlbumId = Guid.Parse("5f67fd16-360c-4504-80ab-f5bb47614d96")
							},
							new SongDTO
							{
								Name = "Song3",
								Id = Guid.NewGuid(),
								UploadDate = DateTime.Now,
								SongNameInCloud = "ssadasdsadasdas",
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
						CoverImageNameInCloud = "ssadasdsadasdas",
						UploadDate = DateTime.Now,
						Songs = new List<SongDTO>()
					}
			},
			{"AlbumNameNull",
				new AlbumDTO
					{
						Id = Guid.Parse("5f67fd16-360c-4504-80ab-f5bb47614d96"),
						UserName = "Username1",
						CoverImageNameInCloud = "ssadasdsadasdas",
						UploadDate = DateTime.Now,
						Songs = new List<SongDTO>()
						{
							new SongDTO
							{
								Name = "Song1",
								Id = Guid.NewGuid(),
								UploadDate = DateTime.Now,
								SongNameInCloud = "ssadasdsadasdas",
								AlbumId = Guid.Parse("5f67fd16-360c-4504-80ab-f5bb47614d96")
							},
							new SongDTO
							{
								Name = "Song2",
								Id = Guid.NewGuid(),
								UploadDate = DateTime.Now,
								SongNameInCloud = "ssadasdsadasdas",
								AlbumId = Guid.Parse("5f67fd16-360c-4504-80ab-f5bb47614d96")
							},
							new SongDTO
							{
								Name = "Song3",
								Id = Guid.NewGuid(),
								UploadDate = DateTime.Now,
								SongNameInCloud = "ssadasdsadasdas",
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
						Name = "",
						CoverImageNameInCloud = "ssadasdsadasdas",
						UploadDate = DateTime.Now,
						Songs = new List<SongDTO>()
						{
							new SongDTO
							{
								Name = "Song1",
								Id = Guid.NewGuid(),
								UploadDate = DateTime.Now,
								SongNameInCloud = "ssadasdsadasdas",
								AlbumId = Guid.Parse("5f67fd16-360c-4504-80ab-f5bb47614d96")
							},
							new SongDTO
							{
								Name = "Song2",
								Id = Guid.NewGuid(),
								UploadDate = DateTime.Now,
								SongNameInCloud = "ssadasdsadasdas",
								AlbumId = Guid.Parse("5f67fd16-360c-4504-80ab-f5bb47614d96")
							},
							new SongDTO
							{
								Name = "Song3",
								Id = Guid.NewGuid(),
								UploadDate = DateTime.Now,
								SongNameInCloud = "ssadasdsadasdas",
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
						Name = "Album1",
						CoverImageNameInCloud = "ssadasdsadasdas",
						UploadDate = DateTime.Now.AddDays(1),
						Songs = new List<SongDTO>()
						{
							new SongDTO
							{
								Name = "Song1",
								Id = Guid.NewGuid(),
								UploadDate = DateTime.Now,
								SongNameInCloud = "ssadasdsadasdas",
								AlbumId = Guid.Parse("5f67fd16-360c-4504-80ab-f5bb47614d96")
							},
							new SongDTO
							{
								Name = "Song2",
								Id = Guid.NewGuid(),
								UploadDate = DateTime.Now,
								SongNameInCloud = "ssadasdsadasdas",
								AlbumId = Guid.Parse("5f67fd16-360c-4504-80ab-f5bb47614d96")
							},
							new SongDTO
							{
								Name = "Song3",
								Id = Guid.NewGuid(),
								UploadDate = DateTime.Now,
								SongNameInCloud = "ssadasdsadasdas",
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
						Name = "Album1",
						CoverImageNameInCloud = "ssadasdsadasdas",
						UploadDate = DateTime.Now,
						Songs = new List<SongDTO>()
						{
							new SongDTO
							{
								Name = "Song1",
								Id = Guid.Parse("00000000-0000-0000-0000-000000000000"),
								UploadDate = DateTime.Now,
								SongNameInCloud = "ssadasdsadasdas",
								AlbumId = Guid.Parse("5f67fd16-360c-4504-80ab-f5bb47614d96")
							},
							new SongDTO
							{
								Name = "Song2",
								Id = Guid.Parse("00000000-0000-0000-0000-000000000000"),
								UploadDate = DateTime.Now,
								SongNameInCloud = "ssadasdsadasdas",
								AlbumId = Guid.Parse("5f67fd16-360c-4504-80ab-f5bb47614d96")
							},
							new SongDTO
							{
								Name = "Song3",
								Id = Guid.Parse("00000000-0000-0000-0000-000000000000"),
								UploadDate = DateTime.Now,
								SongNameInCloud = "ssadasdsadasdas",
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
						Name = "Album1",
						CoverImageNameInCloud = "ssadasdsadasdas",
						UploadDate = DateTime.Now,
						Songs = new List<SongDTO>()
						{
							new SongDTO
							{
								Name = "Song1",
								Id = Guid.NewGuid(),
								UploadDate = DateTime.Now,
								SongNameInCloud = "ssadasdsadasdas",
								AlbumId = Guid.Parse("5f67fd16-360c-4504-80ab-f5bb47614d00")
							},
							new SongDTO
							{
								Name = "Song2",
								Id = Guid.NewGuid(),
								UploadDate = DateTime.Now,
								SongNameInCloud = "ssadasdsadasdas",
								AlbumId = Guid.Parse("5f67fd16-360c-4504-80ab-f5bb47614d00")
							},
							new SongDTO
							{
								Name = "Song3",
								Id = Guid.NewGuid(),
								UploadDate = DateTime.Now,
								SongNameInCloud = "ssadasdsadasdas",
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
						Name = "Album1",
						CoverImageNameInCloud = "ssadasdsadasdas",
						UploadDate = DateTime.Now,
						Songs = new List<SongDTO>()
						{
							new SongDTO
							{
								Name = "Song1",
								Id = Guid.NewGuid(),
								UploadDate = DateTime.Now,
								SongNameInCloud = "ssadasdsadasdas",
								AlbumId = Guid.Parse("5f67fd16-360c-4504-80ab-f5bb47614d96")
							},
							new SongDTO
							{
								Name = "Song2",
								Id = Guid.NewGuid(),
								UploadDate = DateTime.Now,
								SongNameInCloud = "ssadasdsadasdas",
								AlbumId = Guid.Parse("5f67fd16-360c-4504-80ab-f5bb47614d96")
							},
							new SongDTO
							{
								Name = "Song3",
								Id = Guid.NewGuid(),
								UploadDate = DateTime.Now,
								SongNameInCloud = "ssadasdsadasdas",
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
						Name = "Album1",
						CoverImageNameInCloud = "ssadasdsadasdas",
						UploadDate = DateTime.Now,
						Songs = new List<SongDTO>()
						{
							new SongDTO
							{
								Name = "Song1",
								Id = Guid.NewGuid(),
								UploadDate = DateTime.Now,
								AlbumId = Guid.Parse("5f67fd16-360c-4504-80ab-f5bb47614d96")
							},
							new SongDTO
							{
								Name = "Song2",
								Id = Guid.NewGuid(),
								UploadDate = DateTime.Now,
								AlbumId = Guid.Parse("5f67fd16-360c-4504-80ab-f5bb47614d96")
							},
							new SongDTO
							{
								Name = "Song3",
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
						Name = "Album1",
						CoverImageNameInCloud = "ssadasdsadasdas",
						UploadDate = DateTime.Now,
						Songs = new List<SongDTO>()
						{
							new SongDTO
							{
								Name = "Song1",
								Id = Guid.NewGuid(),
								UploadDate = DateTime.Now.AddDays(1),
								SongNameInCloud = "ssadasdsadasdas",
								AlbumId = Guid.Parse("5f67fd16-360c-4504-80ab-f5bb47614d96")
							},
							new SongDTO
							{
								Name = "Song2",
								Id = Guid.NewGuid(),
								UploadDate = DateTime.Now.AddDays(1),
								SongNameInCloud = "ssadasdsadasdas",
								AlbumId = Guid.Parse("5f67fd16-360c-4504-80ab-f5bb47614d96")
							},
							new SongDTO
							{
								Name = "Song3",
								Id = Guid.NewGuid(),
								UploadDate = DateTime.Now.AddDays(1),
								SongNameInCloud = "ssadasdsadasdas",
								AlbumId = Guid.Parse("5f67fd16-360c-4504-80ab-f5bb47614d96")
							},
						}
					}
			},
		};
	}
}
