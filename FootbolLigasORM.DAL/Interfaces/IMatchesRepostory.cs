using FootbolLigasORM.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootbolLigasORM.DAL.Interfaces
{
    public interface IMatchesRepostory
    {
            public void AddMatch(Matches match);
            public void UpdateMatch(Matches match);
            public void DeleteMatch(int matchId);
            public Matches GetMatchById(int matchId);
            public List<Matches> GetAllMatches();
    }
}
