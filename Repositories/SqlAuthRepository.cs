using HorseRace_API.Data;
using HorseRace_API.Models.Domain;
using HorseRace_API.Models.Dto;
using Microsoft.EntityFrameworkCore;

namespace HorseRace_API.Repositories
{
    public class SqlAuthRepository : IAuthRepository
    {
        private readonly AuthDbContext authDb;

        public SqlAuthRepository(AuthDbContext authDb)
        {
            this.authDb = authDb;
        }

        public async Task<User> AddUserAsync(User user)
        {
            await authDb.Users.AddAsync(user);
            await authDb.SaveChangesAsync();
            return user;
        }

        public async Task<User> getUserAsync(UserCredintials userCredintials)
        {
            var user = await authDb.Users.FirstOrDefaultAsync(x => x.Email == userCredintials.Email);
            if(user == null)
            {
                throw new Exception("User Not Found");
            }
            return user;
        }
    }
}
