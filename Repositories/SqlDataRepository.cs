﻿using HorseRace_API.Data;
using HorseRace_API.Models.Domain;
using HorseRace_API.Models.Dto;
using Microsoft.EntityFrameworkCore;

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

        public async Task<LookUpType> AddLookUpTypeAsync(LookUpType lookUpType)
        {
            await dbContext.LookUpTypes.AddAsync(lookUpType);
            await dbContext.SaveChangesAsync();
            return lookUpType;
        }

        public async Task<LookUpValue> AddLookUpValueAsync(LookUpValue lookUpValue)
        {
            await dbContext.LookUpValues.AddAsync(lookUpValue);
            await dbContext.SaveChangesAsync();
            return lookUpValue;
        }

        public async Task<LookUpType> DeleteLookUpTypeAsync(Guid lookUpTypeId)
        {
            var lookupType = await dbContext.LookUpTypes.FirstOrDefaultAsync(x => x.Id == lookUpTypeId);
            if (lookupType == null)
            {
                throw new Exception("invalid Guid");
            }
            dbContext.LookUpTypes.Remove(lookupType);
            await dbContext.SaveChangesAsync();
            return lookupType;
        }

        public async Task<LookUpValue> DeleteLookUpValueAsync(Guid lookUpValueId)
        {
            var lookUpValue = await dbContext.LookUpValues.FirstOrDefaultAsync(x => x.Id == lookUpValueId);
            if(lookUpValue == null)
            {
                throw new Exception("Invalid Id");
            }
            dbContext.LookUpValues.Remove(lookUpValue);
            await dbContext.SaveChangesAsync();
            return lookUpValue;
        }

        public async Task<LookUpType> GetByIdAsync(Guid lookUpTypeId) => await dbContext.LookUpTypes.Include(it => it.Values).FirstOrDefaultAsync(it => it.Id == lookUpTypeId);

        public async Task<List<LookUpType>> GetLookUpTypesAsync()
        {
            return await dbContext.LookUpTypes.Include(it => it.Values).ToListAsync();
        }

        public async Task<List<LookUpValue>> GetLookUpValuesAsync()
        {
            return await dbContext.LookUpValues.ToListAsync();
        }


        public async Task<LookUpType> UpdateLookUpTypeAsync(UpdateLookUpType updateLookUpType)
        {
            var item = await dbContext.LookUpTypes.FirstOrDefaultAsync(x => x.Id == updateLookUpType.Id);
            if (item == null) 
            {
                throw new Exception("Invalid id");
            }
            item.Update(updateLookUpType);
            await dbContext.SaveChangesAsync();
            return item;
        }

        public async Task<LookUpValue> UpdateLookUpValuesAsync(UpdateLookUpValue updateLookUpValue)
        {
            var item = await dbContext.LookUpValues.FirstOrDefaultAsync(x => x.Id == updateLookUpValue.Id);
            if (item == null)
            {
                throw new Exception("Invalid id");
            }
            item.Update(updateLookUpValue);
            await dbContext.SaveChangesAsync();
            return item;
        }
    }
}
