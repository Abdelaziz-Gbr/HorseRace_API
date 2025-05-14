using HorseRace_API.Models.Domain;
using HorseRace_API.Models.Dto;

namespace HorseRace_API.Repositories
{
    public interface IDataRepository
    {
        public Task<Customer> AddCustomerAsync(Customer customer);

        public Task<List<LookUpType>> GetLookUpTypesAsync();
        public Task<LookUpType> UpdateLookUpTypeAsync(UpdateLookUpType lookUpType);
        public Task<LookUpType> DeleteLookUpTypeAsync(Guid lookUpTypeId);
        public Task<LookUpType> AddLookUpTypeAsync(LookUpType lookUpType);
        public Task<LookUpType> GetByIdAsync(Guid lookUpTypeId);

        public Task<List<LookUpValue>> GetLookUpValuesAsync();
        public Task<LookUpValue> UpdateLookUpValuesAsync(UpdateLookUpValue lookUpValue);
        public Task<LookUpValue> DeleteLookUpValueAsync(Guid lookUpValueId);
        public Task<LookUpValue> AddLookUpValueAsync(LookUpValue lookUpValue);
        /*public Task<LookUpType> GetType(Guid lookUpValueId);*/
    }
}
