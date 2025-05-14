using HorseRace_API.Models.Dto;
using System.ComponentModel.DataAnnotations;

namespace HorseRace_API.Models.Domain
{
    public class LookUpType
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required]
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        public ICollection<LookUpValue> Values { get; set; }

        public void Update(UpdateLookUpType newLookUpType)
        {
            this.Name = newLookUpType.Name;
            this.UpdatedAt = DateTime.Now;
        }
    }
}
