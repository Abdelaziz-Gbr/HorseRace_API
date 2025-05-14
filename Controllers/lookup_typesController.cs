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
    public class lookup_typesController : ControllerBase
    {
        private readonly IDataRepository dataRepository;

        public lookup_typesController(IDataRepository dataRepository)
        {
            this.dataRepository = dataRepository;
        }
        [HttpGet]
        public async Task<ActionResult> GetAllLookupTypes()
        {
            var items = await dataRepository.GetLookUpTypesAsync();
            return Ok(items);
        }

        [HttpPost]
        public async Task<ActionResult> AddLookupType([FromBody] AddLookUpType lookUpType)
        {
            if (!ModelState.IsValid) 
            {
                return BadRequest(ModelState);
            }
            var newLookUpType = new LookUpType { Name = lookUpType.Name };
            var item = await dataRepository.AddLookUpTypeAsync(newLookUpType);
            return Ok(item);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateLookUpType(UpdateLookUpType lookUpTypeDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var modifiedLookupType = await dataRepository.UpdateLookUpTypeAsync(lookUpTypeDto);
            return Ok(modifiedLookupType);
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteLookUpType(Guid LookUpTypeId)
        {
            var deletedLookUp = await dataRepository.DeleteLookUpTypeAsync(LookUpTypeId);
            return Ok(deletedLookUp);
        }

       /* [HttpGet]
        [Route("{id:guid}")]
        public async Task<ActionResult> GetValuesForAspcificType([FromRoute] Guid id)
        {

        }*/
    }
}
