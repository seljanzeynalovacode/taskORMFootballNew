using FootbolLigasORM.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootbolLigasORM.DAL.Interfaces
{
    public interface IGoalsRepostory
    {
        public void AddGoal(Goals goal);
        public void UpdateGoal(Goals goal);
        public void DeleteGoal(int goalId);
        public Goals GetGoalByClubId(int goalId, int clubId);
        public Goals GetGoalByPlayerId(int goalId, int playerId);

        public List<Goals> GetAllGoals();

    }
}
