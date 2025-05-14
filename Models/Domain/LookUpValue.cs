using HorseRace_API.Models.Dto;
using System.ComponentModel.DataAnnotations;

namespace HorseRace_API.Models.Domain
{
    public class LookUpValue
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required]
        public Guid LookUpTypeId { get; set; }
        //public LookUpType lookUpType { get; set; }
        [Required]
        public string Value { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        public void Update(UpdateLookUpValue updateLookUpValue)
        {
            Value = updateLookUpValue.Value;
            UpdatedAt = DateTime.Now;
        }
    }
}
