namespace HorseRace_API.Models.Dto
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public String Name { get; set; }
        public String Email { get; set; }
        public bool Active { get; set; }
        public String Role { get; set; }
    }
}
