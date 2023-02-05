using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MusicPlayerBackend.Helpers;
using MusicPlayerBackend.Models.DTOs;
using MusicPlayerBackend.Models.JWT;
using MusicPlayerBackend.Repositories.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MusicPlayerBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly Validator _validator;
        private readonly IUserRepository _userRepository;

        public AuthenticationController(IUserRepository userRepository)
        {
            _validator = new Validator();
            _userRepository = userRepository;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserCredentialsDTO user)
        {
            if (user == null || !_validator.AreUserCredentialsValid(user)) return BadRequest("Invalid user request");

            //TODO: check for user in the database here. if user exists then check if password matches.
            if (await _userRepository.CheckIfUserExistsByUsernameAndPassword(user))
            {
                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(ConfigurationManager.AppSetting["JWT:Secret"]));
                var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
                var tokenOptions = new JwtSecurityToken
                    (
                        issuer: ConfigurationManager.AppSetting["JWT:ValidIssuer"],
                        audience: ConfigurationManager.AppSetting["JWT:ValidAudience"],
                        claims: new List<Claim>()
                        {
                            new Claim("Username", user.UserName)
                        },
                        expires: DateTime.Now.AddMinutes(10),
                        signingCredentials: signinCredentials
                    ); ;
                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
                return Ok(new JWTTokenResponse { Token = tokenString });
            }
            return Unauthorized();
        }
    }
}
