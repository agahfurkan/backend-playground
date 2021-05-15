using System.Threading.Tasks;
using ApiPlayground.Entities;
using ApiPlayground.Models;
using ApiPlayground.Models.Dtos;
using ApiPlayground.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ApiPlayground.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly IAuthRepository _authRepository;
        private readonly IUserRepository _userRepository;

        public LoginController(IUserRepository userRepository, IAuthRepository authRepository)
        {
            _userRepository = userRepository;
            _authRepository = authRepository;
        }

        [HttpPost("Login")]
        public async Task<ActionResult<LoginUserResponse>> LoginUser(LoginUserDto loginUserDto)
        {
            var tempUser = await _userRepository.GetUserByUsernameAsync(loginUserDto.Username);
            if (tempUser == null) return Ok(new LoginUserResponse {IsSuccess = false, Message = "Invalid credentials"});
            var token = _authRepository.GenerateJwtToken(loginUserDto.Username, loginUserDto.Password);
            return Ok(new LoginUserResponse {IsSuccess = true, Token = token, UserId = tempUser.UserId});
        }

        [HttpPost("Register")]
        public async Task<ActionResult<GenericResponseModel>> RegisterNewUser(RegisterNewUserDto registerNewUserDto)
        {
            var tempUser = await _userRepository.GetUserByUsernameAsync(registerNewUserDto.Username);
            if (tempUser != null)
                return Ok(new GenericResponseModel {IsSuccess = false, Message = "User Already Exist"});
            await _userRepository.AddAsync(new UserEntity
            {
                Username = registerNewUserDto.Username,
                Password = registerNewUserDto.Password
            });
            return Ok(new GenericResponseModel {IsSuccess = true, Message = "New User Created"});
        }

        [HttpPost("ValidateToken")]
        public ActionResult<GenericResponseModel> ValidateToken(ValidateTokenDto validateTokenDto)
        {
            var isTokenValid = _authRepository.ValidateJwtToken(validateTokenDto.Token);
            return Ok(new GenericResponseModel
                {IsSuccess = isTokenValid, Message = isTokenValid ? "Token is valid" : "Token invalid"});
        }
    }
}