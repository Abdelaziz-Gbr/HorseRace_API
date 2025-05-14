using HorseRace_API.Models.Domain;
using HorseRace_API.Models.Dto;
using HorseRace_API.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HorseRace_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "admin")]
    public class LookUp_ValuesController : ControllerBase
    {
        private readonly IDataRepository dataRepository;

        public LookUp_ValuesController(IDataRepository dataRepository)
        {
            this.dataRepository = dataRepository;
        }

        [HttpPost]
        public async Task<ActionResult> AddLookupValueItem([FromBody] AddlookupValue addlookupValue)
        {
            if (!ModelState.IsValid) 
            {
                return BadRequest(ModelState);
            }
            var newLookUpValue = new LookUpValue
            {
                LookUpTypeId = addlookupValue.LookUpTypeId,
                Value = addlookupValue.Value
            };
            var addedLookupValueItem = await dataRepository.AddLookUpValueAsync(newLookUpValue);
            return Ok(addedLookupValueItem);
        }

        [HttpGet]
        public async Task<ActionResult> GetLookUpValues()
        {
            var values = await dataRepository.GetLookUpValuesAsync();
            return Ok(values);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateLookUpValue([FromBody] UpdateLookUpValue updateLookUpValue)
        {
            var updatedItem = await dataRepository.UpdateLookUpValuesAsync(updateLookUpValue);
            return Ok(updatedItem);
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteLookUpValue(Guid itemId)
        {
            var deletedItem = await dataRepository.DeleteLookUpValueAsync(itemId);
            return Ok(deletedItem);
        }
        
    }
}
