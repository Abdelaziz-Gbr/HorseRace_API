using HorseRace_API.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace HorseRace_API.Data
{
    public class AuthDbContext : DbContext
    {
        public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
    }
}
