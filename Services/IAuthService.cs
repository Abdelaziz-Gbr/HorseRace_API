using HorseRace_API.Models.Domain;
using HorseRace_API.Models.Dto;
using HorseRace_API.Repositories;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace HorseRace_API.Services
{
    public interface IAuthService
    {
        public Task<String> GetUserTokenAsync(UserCredintials userCredintials);
        public Task<User> SaveUserAsync(UserRegisteration userInfo);
    }
}

