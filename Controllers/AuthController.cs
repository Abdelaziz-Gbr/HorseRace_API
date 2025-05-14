using HorseRace_API.Models.Dto;
using HorseRace_API.Repositories;
using HorseRace_API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HorseRace_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService authService;
        private readonly IAuthRepository authRepository;

        public AuthController(IAuthService authService, IAuthRepository authRepository)
        {
            this.authService = authService;
            this.authRepository = authRepository;
        }
        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult> RegisterUser([FromBody] UserRegisteration userInfo)
        {
            var user = await authService.SaveUserAsync(userInfo);
            if (user == null)
            {
                return BadRequest("Invalid Data");
            }
            return Ok();
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult> GetAllUsers()
        {
            var users = await authRepository.getUsersAsync();
            return Ok(users);
        }

        [HttpPut]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult> UpdateUser([FromBody] UpdateUser updateUser)
        {
            return BadRequest();
        }


        [HttpPost]
        [Route("Login")]
        public async Task<ActionResult> LogUserIn([FromBody] UserCredintials userCredintials)
        {
            var secureKey = await authService.GetUserTokenAsync(userCredintials);
            if (secureKey == null)
            {
                return BadRequest("Invlid user Credintials");
            }
            return Ok(
                new {
                    message = "log in success", 
                    data = new {access_token = secureKey
                    } 
                });
        }
    }
}
