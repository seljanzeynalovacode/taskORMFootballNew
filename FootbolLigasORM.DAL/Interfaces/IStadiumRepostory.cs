using FootbolLigasORM.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootbolLigasORM.DAL.Interfaces
{
    public interface IStadiumRepostory
    {
        public void AddStadium(Stadiums stadium);
        public void UpdateStadium(Stadiums stadium);
        public void DeleteStadium(int stadiumId);
        public Stadiums GetStadiumById(int stadiumId);
        public List<Stadiums> GetAllStadiums();
    }
}
