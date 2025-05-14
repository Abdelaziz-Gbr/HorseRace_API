using HorseRace_API.Models.Domain;

namespace HorseRace_API.Repositories
{
    public interface IDataRepository
    {
        public Task<Customer> AddCustomerAsync(Customer customer);
    }
}
