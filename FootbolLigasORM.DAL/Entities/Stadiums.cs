using System;
using System.Collections.Generic;

namespace FootbolLigasORM.DAL.Entities
{
    public class Stadiums : BaseEntity
    {
        // Stadium name
        public string Name { get; set; } = string.Empty;

        // City where the stadium is located
        public string City { get; set; } = string.Empty;

        // Full address
        public string Address { get; set; } = string.Empty;

        // Seating capacity
        public int Capacity { get; set; }
        // Playing surface (e.g., Natural Grass, Artificial)
        public string SurfaceType { get; set; } = string.Empty;

        // Optional reference to the club that primarily uses this stadium
        public int? ClubId { get; set; }
        public Clubs? Club { get; set; }

        // Matches played at this stadium
        public List<Matches> Matches { get; set; } = new();
    }
}
