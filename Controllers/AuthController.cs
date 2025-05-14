using HorseRace_API.Models.Dto;
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

        public AuthController(IAuthService authService)
        {
            this.authService = authService;
        }
        [HttpPost]
        [Route("Register")]
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

        [HttpPost]
        [Route("Login")]
        public async Task<ActionResult> LogUserIn([FromBody] UserCredintials userCredintials)
        {
            var key = await authService.GetUserTokenAsync(userCredintials);
            if (key == null)
            {
                return BadRequest("Invlid user Credintials");
            }
            return Ok(key);
        }
    }
}
