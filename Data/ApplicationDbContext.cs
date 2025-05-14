using HorseRace_API.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace HorseRace_API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Customer> Customers { get; set; }

    }
}
