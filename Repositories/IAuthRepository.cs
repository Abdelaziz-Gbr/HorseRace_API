using HorseRace_API.Models.Domain;
using HorseRace_API.Models.Dto;

namespace HorseRace_API.Repositories
{
    public interface IAuthRepository
    {
        public Task<User> getUserAsync(UserCredintials userCredintials);
        public Task<List<User>> getUsersAsync();
        public Task<User> UpdateUserAsync(UpdateUser updateUser);

        public Task<User> DeleteUserAsync(Guid user_id);
        public Task<User> AddUserAsync(User user);
    }
}
