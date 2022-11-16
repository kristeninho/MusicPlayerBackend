using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MusicPlayerBackend.Helpers;
using MusicPlayerBackend.Models.DTOs;
using MusicPlayerBackend.Repositories.Interfaces;

namespace MusicPlayerBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController, Authorize]
    public class SongController : ControllerBase
    {
        private readonly ISongRepository _songRepository;
        private readonly Validator _validator;
        public SongController(ISongRepository songRepository)
        {
            _songRepository = songRepository;
            _validator = new Validator();
        }

        // POST: api/song
        // Will add song to album
        [HttpPost("AddSong")]
        public async Task<ActionResult<SongDTO>> AddSong(SongDTO song)
        {
            if (!_validator.IsSongDTOValid(song)) return BadRequest("Invalid song");

            var songResult = await _songRepository.AddAsync(song);

            return Ok(songResult);
        }

        // PUT: api/album
        // Will update the song
        [HttpPut("UpdateSong")]
        public async Task<ActionResult<SongDTO>> UpdateSong(SongDTO song)
        {
            if (!_validator.IsSongDTOValid(song)) return BadRequest("Invalid song");
            if (!await _songRepository.CheckIfSongExists(song.Id)) return NotFound("Song does not exist");

            var songResult = await _songRepository.UpdateAsync(song);

            return Ok(songResult);
        }

        // DELETE: api/song
        [HttpDelete("DeleteSong")]
        public async Task<ActionResult<string>> DeleteSong(SongDTO song)
        {
            if (!_validator.IsSongDTOValid(song)) return BadRequest("Invalid song");
            if (!await _songRepository.CheckIfSongExists(song.Id)) return NotFound("Song does not exist");

            var result = await _songRepository.DeleteAsync(song.Id.ToString());

            return Ok(result);
        }
    }
}
