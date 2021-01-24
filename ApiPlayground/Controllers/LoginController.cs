using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
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
        private readonly DbContextClass _contextClass;
        public IConfiguration _configuration;
        public LoginController(IConfiguration config,DbContextClass contextClass)
        {
            _configuration = config;
            _contextClass = contextClass;
        }

        [HttpPost]
        public async Task<IActionResult> Post(User _user)
        {
            var user =await GetUser(_user.Username,_user.Password);
            if (user == null)
            {
                return BadRequest("Invalid credentials");
            }
            
            var claims = new[] {
                    new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                    new Claim("username", user.Username),
                    new Claim("password", user.Password),
                };
 
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
 
                var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
 
                var token = new JwtSecurityToken(_configuration["Jwt:Issuer"], _configuration["Jwt:Audience"], claims, expires: DateTime.UtcNow.AddDays(1), signingCredentials: signIn);
 
                return Ok(new JwtSecurityTokenHandler().WriteToken(token));
            
        }
        private async Task<User> GetUser(string username, string password)
        {
            return await _contextClass.Users.FirstOrDefaultAsync(user =>
                user.Username == username && user.Password == password);
        }
    }
}