using HorseRace_API.Helpers;
using HorseRace_API.Models.Dto;

namespace HorseRace_API.Models.Domain
{
    public class User
    {
        public Guid Id { get; set; }
        public String Name { get; set; }
        public String Email { get; set; }
        public String HashedPassword { get; set; }

        public bool Active { get; set; } = true;
        public String Role { get; set; } = "customer";

        internal void Update(UpdateUser updateUser)
        {
            Email = updateUser.Email;
            HashedPassword = PasswordHasher.HashPassword(updateUser.Password);
            Active = updateUser.Active;
        }
    }
}
