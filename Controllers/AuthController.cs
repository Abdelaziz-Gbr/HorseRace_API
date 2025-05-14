using AutoMapper;
using HorseRace_API.Models.Dto;
using HorseRace_API.Repositories;
using HorseRace_API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HorseRace_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository authRepository;
        private readonly IAuthService authService;
        private readonly IMapper mapper;

        public AuthController(IAuthRepository authRepository, IAuthService authService, IMapper mapper)
        {
            this.authRepository = authRepository;
            this.authService = authService;
            this.mapper = mapper;
        }

        [HttpPost]
        [Route("Login")]
        public async Task<ActionResult> LogUserIn([FromBody] UserCredintials userCredintials)
        {
            var user = await authRepository.getUserAsync(userCredintials);
            if (user == null)
            {
                return BadRequest(
                    new
                    {
                        message = "User not found"
                    });
            }
            var secureKey = await authService.GetUserTokenAsync(userCredintials);
            if (secureKey == null)
            {
                return BadRequest("Invlid user Credintials");
            }
            return Ok(
                new
                {
                    message = "log in success",
                    data = new
                    {
                        access_token = secureKey,
                        user = mapper.Map<UserDto>(user)
                    }
                });
        }
    }
}
