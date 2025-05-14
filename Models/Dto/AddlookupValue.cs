using HorseRace_API.Models.Domain;
using System.ComponentModel.DataAnnotations;

namespace HorseRace_API.Models.Dto
{
    public class AddlookupValue
    {
        [Required]
        public Guid LookUpTypeId { get; set; }
        [Required]
        public string Value { get; set; }
    }
}
