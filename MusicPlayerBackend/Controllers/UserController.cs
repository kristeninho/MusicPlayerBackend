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
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly UserCredentialsValidator _userCredentialsValidator;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
            _userCredentialsValidator = new UserCredentialsValidator();
        }

        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UserCredentialsDTO>> AddUser(UserCredentialsDTO user)
        {
            if(!_userCredentialsValidator.AreUserCredentialsValid(user)) return BadRequest("Invalid user credentials");
            if (await _userRepository.CheckIfUserWithSameNameExists(user.UserName)) return BadRequest("Username already taken");

            var userResult = await _userRepository.AddAsync(user);

            return Ok(userResult);
        }
    }
}
