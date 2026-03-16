using FootbolLigasORM.DAL.Context;
using FootbolLigasORM.DAL.Entities;
using FootbolLigasORM.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootbolLigasORM.DAL.Repostories
{
    public class ClubsRepostory : IClubsRepostory
    {
        private readonly AppDbContext _db;
        public ClubsRepostory(AppDbContext db)
        {
            _db = db;
        }
        public void AddClub(Clubs club)
        {
            _db.Clubs.Add(club);
            _db.SaveChanges();

        }

        public void DeleteClub(int clubId)
        {
            var club = _db.Clubs.Find(clubId);
            if (club != null)
            {
                _db.Clubs.Remove(club);
                _db.SaveChanges();
            }
        }

        public List<Clubs> GetAllClubs()
        {
            return _db.Clubs.ToList();

        }

        public Clubs GetClubById(int clubId)
        {
            return _db.Clubs.FirstOrDefault(c => c.Id == clubId);
        }

        public void UpdateClub(Clubs club)
        {
            _db.Clubs.Update(club);
            _db.SaveChanges();
        }
    }
}
