﻿using System;
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
        private readonly IConfiguration _configuration;
        private readonly DbContextClass _contextClass;

        public LoginController(IConfiguration config, DbContextClass contextClass)
        {
            _configuration = config;
            _contextClass = contextClass;
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginUser(User user)
        {
            var tempUser = await GetUser(user.Username, user.Password);
            if (tempUser == null) return BadRequest("Invalid credentials");

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                new Claim("username", user.Username),
                new Claim("password", user.Password)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));

            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_configuration["Jwt:Issuer"], _configuration["Jwt:Audience"], claims,
                expires: DateTime.UtcNow.AddDays(1), signingCredentials: signIn);

            return Ok(new HttpReturnModel{Code = 1,Message = new JwtSecurityTokenHandler().WriteToken(token)});
        }

        private async Task<User> GetUser(string username, string password)
        {
            return await _contextClass.User.FirstOrDefaultAsync(user =>
                user.Username == username && user.Password == password);
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterNewUser(User user)
        {
            if (!ModelState.IsValid) return BadRequest();
            var tempUser = await _contextClass.User.FirstOrDefaultAsync(mUser =>
                user.Username == mUser.Username);
            if (tempUser != null) return Ok(new HttpReturnModel {Code = -1, Message = "User Already Exist"});
            await _contextClass.User.AddAsync(user);
            await _contextClass.SaveChangesAsync();
            return Ok(new HttpReturnModel {Code = 1, Message = "New User Created"});
        }
    }
}