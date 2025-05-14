namespace HorseRace_API.Models.Dto
{
    public class UpdateUser
    {
        public Guid Id { get; set; }
        public String Name { get; set; }
        public String Email { get; set; }
        public String HashedPassword { get; set; }

        public bool Active { get; set; } = true;
        public String Role { get; set; } = "customer";
    }
}
