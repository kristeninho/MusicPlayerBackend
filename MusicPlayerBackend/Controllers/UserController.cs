using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MusicPlayerBackend.Helpers;
using MusicPlayerBackend.Models.DTOs;
using MusicPlayerBackend.Repositories.Interfaces;

namespace MusicPlayerBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly Validator _validator;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
            _validator = new Validator();
        }

        // POST: api/User
        // Will create user if credentials are valid and return its credentials
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        // TODO: think about adding authorize here as well, since it will block against big attacks and ->
        // -> use this request from my own admin account (so only admin can create users)
        [HttpPost("AddUser")]
        public async Task<ActionResult<UserCredentialsDTO>> AddUser(UserCredentialsDTO user)
        {
            if(!_validator.AreUserCredentialsValid(user)) return BadRequest("Invalid user credentials");
            if (await _userRepository.CheckIfUserExistsByUsername(user.UserName)) return BadRequest("Username already taken");

            var userResult = await _userRepository.AddAsync(user);

            return Ok(userResult);
        }

        // GET: api/user
        // Will return the username with all of its albums and songs
		[HttpGet("GetUserData"), Authorize]
        public async Task<ActionResult<UserDataDTO>> GetUserData(string userName)
		{
            if (!_validator.IsUserNameValid(userName)) return BadRequest("Invalid username");
            if (!await _userRepository.CheckIfUserExistsByUsername(userName)) return NotFound("User does not exist");
            //previous line maybe unnecessary, because user has to be logged in and have valid userName to be authorized for the request. So has to exist.

            var userData = await _userRepository.GetUserDataAsync(userName);

            return Ok(userData);
		}

		// PUT: api/user
		// Will update user credentials and return new ones
		[HttpPut("UpdateUserPassword"), Authorize]
        public async Task<ActionResult<UserCredentialsDTO>> UpdateUserCredentials(UserCredentialsDTO user)
		{
            if (!_validator.AreUserCredentialsValid(user)) return BadRequest("Invalid user credentials");
            if (!await _userRepository.CheckIfUserExistsByUsername(user.UserName)) return NotFound("User does not exist");
            //previous line maybe unnecessary, because user has to be logged in and have valid userName to be authorized for the request. So has to exist.

            var userData = await _userRepository.UpdateAsync(user);

            return Ok(userData);
        }

		// DELETE: api/user
		// Will delete user from the database
		[HttpDelete("DeleteUser"), Authorize]
        public async Task<ActionResult<string>> DeleteUser(UserCredentialsDTO user)
		{
            if (!_validator.IsUserNameValid(user.UserName)) return BadRequest("Invalid username");
            if (!await _userRepository.CheckIfUserExistsByUsernameAndPassword(user)) return BadRequest("Invalid Password"); //this is like a password confirmation here

            var response = await _userRepository.DeleteAsync(user.UserName);

            return Ok(response);
        }
    }
}
