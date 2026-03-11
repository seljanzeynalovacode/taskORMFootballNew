using System;
using System.Collections.Generic;

namespace FootbolLigasORM.DAL.Entities
{
    public class Players : BaseEntity
    {
        // Player names
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;

        // Date of birth
        public DateTime BirthDate { get; set; }

        // Playing position (e.g., Goalkeeper, Defender, Midfielder, Forward)
        public string Position { get; set; } = string.Empty;

        // Squad shirt number
        public int JerseyNumber { get; set; }
        // Count of goals scored by the player
        public int CountOfGoals { get; set; }

        // Relationship to club: each player belongs to one club
        public int ClubId { get; set; }
        public Clubs? Club { get; set; }

        // Goals scored by the player
        public List<Goals> Goals { get; set; } = new();
    }
}
