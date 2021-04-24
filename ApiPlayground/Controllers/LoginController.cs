using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using ApiPlayground.Entities;
using ApiPlayground.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace ApiPlayground.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly DbContextClass _contextClass;

        public LoginController(IConfiguration config, DbContextClass contextClass)
        {
            _configuration = config;
            _contextClass = contextClass;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> LoginUser(LoginUserDto loginUserDto)
        {
            var tempUser = await GetUser(loginUserDto.Username, loginUserDto.Password);
            if (tempUser == null) return Ok(new ResponseModel {Code = -1, Message = "Invalid credentials"});

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                new Claim("username", loginUserDto.Username),
                new Claim("password", loginUserDto.Password)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));

            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_configuration["Jwt:Issuer"], _configuration["Jwt:Audience"], claims,
                expires: DateTime.UtcNow.AddDays(1), signingCredentials: signIn);

            return Ok(new ResponseModel {Code = 1, Message = new JwtSecurityTokenHandler().WriteToken(token)});
        }

        private async Task<User> GetUser(string username, string password)
        {
            return await _contextClass.User.FirstOrDefaultAsync(user =>
                user.Username == username && user.Password == password);
        }

        [HttpPost("Register")]
        public async Task<IActionResult> RegisterNewUser(RegisterNewUserDto registerNewUserDto)
        {
            if (!ModelState.IsValid) return BadRequest();
            var tempUser = await _contextClass.User.FirstOrDefaultAsync(mUser =>
                registerNewUserDto.Username == mUser.Username);
            if (tempUser != null) return Ok(new ResponseModel {Code = -1, Message = "User Already Exist"});
            await _contextClass.User.AddAsync(new User
                {
                    Username = registerNewUserDto.Username,
                    Password = registerNewUserDto.Password
                }
            );
            await _contextClass.SaveChangesAsync();
            return Ok(new ResponseModel {Code = 1, Message = "New User Created"});
        }

        [HttpPost("ValidateToken")]
        public IActionResult ValidateToken(ValidateTokenDto validateTokenDto)
        {
            try
            {
                var tokenValidationParameters = new TokenValidationParameters
                {
                    ValidateAudience = false,
                    ValidateIssuer = false,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey =
                        new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"])),
                    ValidateLifetime = true
                };

                var tokenHandler = new JwtSecurityTokenHandler();
                SecurityToken securityToken;
                var principal = tokenHandler.ValidateToken(validateTokenDto.Token, tokenValidationParameters,
                    out securityToken);
                var jwtSecurityToken = securityToken as JwtSecurityToken;

                if (jwtSecurityToken == null || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256,
                    StringComparison.InvariantCultureIgnoreCase))
                    return Ok(new ResponseModel {Code = -1, Message = "Token invalid"});
                return Ok(new ResponseModel {Code = 1, Message = "Token is valid"});
            }
            catch (Exception e)
            {
                return Ok(new ResponseModel {Code = -1, Message = "Token invalid"});
            }
        }
    }
}