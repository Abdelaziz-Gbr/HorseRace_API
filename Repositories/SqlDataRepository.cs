using HorseRace_API.Data;
using HorseRace_API.Models.Domain;

namespace HorseRace_API.Repositories
{
    public class SqlDataRepository : IDataRepository
    {
        private readonly ApplicationDbContext dbContext;

        public SqlDataRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<Customer> AddCustomerAsync(Customer customer)
        {
            await dbContext.Customers.AddAsync(customer);
            await dbContext.SaveChangesAsync();
            return customer;
        }
    }
}
