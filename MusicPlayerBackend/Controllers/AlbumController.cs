using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MusicPlayerBackend.Data;
using MusicPlayerBackend.Helpers;
using MusicPlayerBackend.Models;
using MusicPlayerBackend.Models.DTOs;
using MusicPlayerBackend.Repositories.Interfaces;

namespace MusicPlayerBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController, Authorize]
    public class AlbumController : ControllerBase
    {
        private readonly IAlbumRepository _albumRepository;
        private readonly Validator _validator;
		public AlbumController(IAlbumRepository albumRepository)
		{
            _albumRepository = albumRepository;
            _validator = new Validator();
		}

        // POST: api/Album
        // Will add album to user
        [HttpPost]
        public async Task<ActionResult<AlbumDTO>> AddAlbum(AlbumDTO album)
        {
            if (!_validator.IsAlbumDTOValid(album)) return BadRequest("Invalid album");
            //Check here from JWT if the album user is same as JWT login user
            if (await _albumRepository.CheckIfAlbumExists(album.Id)) return BadRequest("Album already exists");

            var albumResult = await _albumRepository.AddAsync(album);

            return Ok(albumResult);
        }

        // PUT: api/album
        // Will update the album
        public async Task<ActionResult<AlbumDTO>> UpdateAlbum(AlbumDTO album)
		{
            if (!_validator.IsAlbumDTOValid(album)) return BadRequest("Invalid album");
            //Check here from JWT if the album user is same as JWT login user
            if (!await _albumRepository.CheckIfAlbumExists(album.Id)) return BadRequest("Album you're trying to update does not exist");

            var albumResult = await _albumRepository.UpdateAsync(album);

            return Ok(albumResult);
        }

        // DELETE: api/album
        // Will delete the album
        public async Task<ActionResult<string>> DeleteAlbum(AlbumDTO album)
		{
            if (!_validator.IsAlbumDTOValid(album)) return BadRequest("Invalid album");
            //Check here from JWT if the album user is same as JWT login user
            if (!await _albumRepository.CheckIfAlbumExists(album.Id)) return BadRequest("Album you're trying to delete does not exist");

            var result = await _albumRepository.DeleteAsync(album.Id.ToString());

            return Ok(result);
        }
    }
}
