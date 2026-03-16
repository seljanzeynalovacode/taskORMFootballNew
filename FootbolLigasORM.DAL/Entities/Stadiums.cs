using System;
using System.Collections.Generic;

namespace FootbolLigasORM.DAL.Entities
{
    public class Stadiums : BaseEntity
    {
        
        public string Name { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public int Capacity { get; set; }
        public string SurfaceType { get; set; } = string.Empty;
        public int? ClubId { get; set; }
        public Clubs? Club { get; set; }

       
        public List<Matches> Matches { get; set; } = new();
    }
}
