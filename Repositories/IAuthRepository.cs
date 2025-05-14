using HorseRace_API.Models.Domain;
using HorseRace_API.Models.Dto;

namespace HorseRace_API.Repositories
{
    public interface IAuthRepository
    {
        public Task<User> getUserAsync(UserCredintials userCredintials);
        public Task<User> AddUserAsync(User user);
    }
}
