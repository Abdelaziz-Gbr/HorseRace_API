﻿namespace HorseRace_API.Models.Dto
{
    public class UpdateUser
    {
        public Guid Id { get; set; }
        public String Email { get; set; }
        public String Password { get; set; }

        public bool Active { get; set; }
    }
}
