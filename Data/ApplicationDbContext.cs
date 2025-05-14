using HorseRace_API.Models.Domain;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace HorseRace_API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<LookUpType> LookUpTypes { get; set; }
        public DbSet<LookUpValue> LookUpValues { get; set; }

    }
}
