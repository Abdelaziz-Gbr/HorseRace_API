using AutoMapper;
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
    public class UsersController : ControllerBase
    {
        private readonly IAuthService authService;
        private readonly IAuthRepository authRepository;
        private readonly IMapper mapper;

        public UsersController(IAuthService authService, IAuthRepository authRepository, IMapper mapper)
        {
            this.authService = authService;
            this.authRepository = authRepository;
            this.mapper = mapper;
        }
        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult> RegisterUser([FromBody] UserRegisteration userInfo)
        {
            var newUser = await authService.SaveUserAsync(userInfo);
            if (newUser == null)
            {
                return BadRequest("Invalid Data");
            }
            return Ok(
                new
            {
                message = "user registered successfuly",
                date = new
                {
                    user = mapper.Map<UserDto>(newUser)
                }
            });
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult> GetAllUsers()
        {
            var users = await authRepository.getUsersAsync();
            return Ok(new
            {
                message = "success",
                data = new
                {
                    users = mapper.Map<List<UserDto>>(users)
                }
            });
        }

        [HttpPut]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult> UpdateUser([FromBody] UpdateUser updateUser)
        {
            var updatedUser = await authRepository.UpdateUserAsync(updateUser);
            return Ok(
                new {
                    message = "user updated successfuly",
                    data = new {
                    user = mapper.Map<UserDto>(updatedUser)
                    }
                });
        }

        [HttpDelete]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult> DeleteUser([FromBody] Guid user_id)
        {
            var deletedUser = await authRepository.DeleteUserAsync(user_id);
            if (deletedUser == null)
            {
                return BadRequest("user not found");
            }
            return Ok(new
            {
                message = "user deleted successfuly",
                date = new
                {
                    user = mapper.Map<UserDto>(deletedUser)
                }
            });
        }


    }
}
