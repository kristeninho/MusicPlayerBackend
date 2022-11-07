using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MusicPlayerBackend.Data;
using MusicPlayerBackend.Models;
using MusicPlayerBackend.Models.DTOs;

namespace MusicPlayerBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController, Authorize]
    public class AlbumController : ControllerBase
    {
        //Add
        [HttpPost]
        public async Task<ActionResult<AlbumDTO>> AddAlbum(AlbumDTO album)
        {
            throw new NotImplementedException();
        }
    }
}
