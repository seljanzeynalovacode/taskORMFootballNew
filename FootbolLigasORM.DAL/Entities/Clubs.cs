using System;
using System.Collections.Generic;

namespace FootbolLigasORM.DAL.Entities
{
    public class Clubs : BaseEntity
    {
        // Club name
        public string Name { get; set; } = string.Empty;

        // Year or date when the club was founded
        public DateTime Founded { get; set; }

        // City where the club is based
        public string City { get; set; } = string.Empty;

        // Current head coach/manager
        public string Manager { get; set; } = string.Empty;

        // Performance of the club
        public int PerformanceRate { get; set; }

        // Optional: reference to the club's main stadium
        public int? MainStadiumId { get; set; }
        public Stadiums? MainStadium { get; set; }

        // Navigation: players belonging to this club
        public List<Players> Players { get; set; } = new();

        // Navigation: stadiums associated with the club (if any)
        public List<Stadiums> Stadiums { get; set; } = new();

        // Navigation: matches where this club is the first or second participant
        public List<Matches> HomeMatches { get; set; } = new();
        public List<Matches> AwayMatches { get; set; } = new();
    }
}
