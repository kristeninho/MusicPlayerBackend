﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MusicPlayerBackend.Helpers;
using MusicPlayerBackend.Models.DTOs;
using MusicPlayerBackend.Models.JWT;
using MusicPlayerBackend.Repositories.Interfaces;
using System.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MusicPlayerBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly UserCredentialsValidator _userCredentialsValidator;
        private readonly IUserRepository _userRepository;

        public AuthenticationController(IUserRepository userRepository)
        {
            _userCredentialsValidator = new UserCredentialsValidator();
            _userRepository = userRepository;
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync([FromBody] UserCredentialsDTO user)
        {
            if (user == null || !_userCredentialsValidator.AreUserCredentialsValid(user)) return BadRequest("Invalid user request");

            //TODO: check for user in the database here. if user exists then check if password matches.
            if (await _userRepository.CheckIfUserExistsByUsernameAndPassword(user))
            {
                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(ConfigurationManager.AppSetting["JWT:Secret"]));
                var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
                var tokenOptions = new JwtSecurityToken
                    (
                        issuer: ConfigurationManager.AppSetting["JWT:ValidIssuer"],
                        audience: ConfigurationManager.AppSetting["JWT:ValidAudience"],
                        claims: new List<Claim>(),
                        expires: DateTime.Now.AddMinutes(10),
                        signingCredentials: signinCredentials
                    );
                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
                return Ok(new JWTTokenResponse { Token = tokenString });
            }
            return Unauthorized();
        }
    }
}