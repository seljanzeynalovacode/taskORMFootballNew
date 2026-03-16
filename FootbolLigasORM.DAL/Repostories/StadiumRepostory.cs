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
    public class StadiumRepostory : IStadiumRepostory
    {
        private readonly AppDbContext _db;
        public StadiumRepostory(AppDbContext db)
        {
            _db = db;
        }
        public void AddStadium(Stadiums stadium)
        {
            _db.Stadiums.Add(stadium);
            _db.SaveChanges();
        }

        public void DeleteStadium(int stadiumId)
        {
            _db.Stadiums.Remove(_db.Stadiums.Find(stadiumId));
            _db.SaveChanges();
        }

        public List<Stadiums> GetAllStadiums()
        {
            return _db.Stadiums.ToList();
        }

        public Stadiums GetStadiumById(int stadiumId)
        {
            return _db.Stadiums.Find(stadiumId);
        }

        public void UpdateStadium(Stadiums stadium)
        {
            _db.Stadiums.Update(stadium);
            _db.SaveChanges();
        }
    }
}
