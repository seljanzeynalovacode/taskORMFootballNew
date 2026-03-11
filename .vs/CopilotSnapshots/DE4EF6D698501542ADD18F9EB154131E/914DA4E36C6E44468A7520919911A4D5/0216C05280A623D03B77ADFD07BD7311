using System;

namespace FootbolLigasORM.DAL.Entities
{
    public class Goals : BaseEntity
    {
        // Match where the goal was scored
        public int MatchId { get; set; }
        public Matches? Match { get; set; }

        // Scoring player
        public int ScorerId { get; set; }
        public Players? Scorer { get; set; }

        // Player who provided the assist (optional)
        public int? AssistById { get; set; }
        public Players? AssistBy { get; set; }

        // Club for which the goal was scored
        public int ClubId { get; set; }
        public Clubs? Club { get; set; }

        // Minute in the match when the goal occurred (can be >90 for extra time)
        public int Minute { get; set; }
    }
}
