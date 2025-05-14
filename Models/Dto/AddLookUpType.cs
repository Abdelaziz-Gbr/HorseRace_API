using HorseRace_API.Models.Domain;
using System.ComponentModel.DataAnnotations;

namespace HorseRace_API.Models.Dto
{
    public class AddLookUpType
    {
        [Required]
        public string Name { get; set; }

    }
}
