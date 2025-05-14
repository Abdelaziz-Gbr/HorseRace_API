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
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository authRepository;
        private readonly IDataRepository dataRepository;
        private readonly IConfiguration configuration;

        public AuthService(IAuthRepository authRepository, IDataRepository dataRepository, IConfiguration configuration)
        {
            this.authRepository = authRepository;
            this.dataRepository = dataRepository;
            this.configuration = configuration;
        }

        public async Task<User> SaveUserAsync(UserRegisteration userInfo)
        {
            var hashedPassword = HashPassword(userInfo.Password);

            var user = new User
            {
                Id = Guid.NewGuid(),
                Name = userInfo.Name,
                Email = userInfo.Email,
                HashedPassword = hashedPassword,
                Role = userInfo.Role
            };
            user = await authRepository.AddUserAsync(user);

            if (userInfo.Role.Equals("customer", StringComparison.OrdinalIgnoreCase))
            {
                var customer = new Customer
                {
                    Id = user.Id,
                    Email = user.Email,
                    Name = user.Name
                };
                await dataRepository.AddCustomerAsync(customer);
            }

            return user;
        }
        public async Task<string> GetUserTokenAsync(UserCredintials userCredintials)
        {
            var userDomain = await authRepository.getUserAsync(userCredintials);
            if (userDomain == null)
            {
                throw new Exception("User Not Found");
            }

            if (!VerifyPassword(userCredintials.Password, userDomain.HashedPassword))
            {
                throw new Exception("Password Incorrect");
            }
            // generate token
            return $"key:{GenerateJwtToken(userDomain)}";
        }

        private string HashPassword(string password)
        {
            byte[] salt = new byte[16];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            byte[] hash = KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 10000,
                numBytesRequested: 32);

            return Convert.ToBase64String(salt) + "." + Convert.ToBase64String(hash);
        }

        private bool VerifyPassword(string password, string storedHash)
        {
            var parts = storedHash.Split('.');
            byte[] salt = Convert.FromBase64String(parts[0]);
            byte[] storedHashBytes = Convert.FromBase64String(parts[1]);

            byte[] hash = KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 10000,
                numBytesRequested: 32);

            return hash.SequenceEqual(storedHashBytes);
        }

        private string GenerateJwtToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(configuration["Jwt:Key"]);
            var claims = new List<Claim>
            {
                new(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new(ClaimTypes.Name, user.Email),
                new(ClaimTypes.Role, user.Role.ToString())
            };

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddHours(2),
                Issuer = configuration["Jwt:isu"],
                Audience = configuration["jwt:aud"],
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
