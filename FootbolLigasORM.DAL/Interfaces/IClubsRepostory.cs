using FootbolLigasORM.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootbolLigasORM.DAL.Interfaces
{
    public interface IClubsRepostory
    {
        public void AddClub(Clubs club);
        public void UpdateClub(Clubs club);
        public void DeleteClub(int clubId);
        public Clubs GetClubById(int clubId);
        public List<Clubs> GetAllClubs();
    }
}
