using FootbolLigasORM.DAL.Context;
using FootbolLigasORM.DAL.Entities;
using FootbolLigasORM.DAL.Interfaces;


namespace FootbolLigasORM.DAL.Repostories
{
    public class GoalRepostory : IGoalsRepostory
    {
        private readonly AppDbContext _db;
        public GoalRepostory(AppDbContext db)
        {
            _db = db;
        }
        public void AddGoal(Goals goal)
        {
            _db.Goals.Add(goal);
            _db.SaveChanges();
        }

        public void DeleteGoal(int goalId)
        {
            _db.Goals.Remove(_db.Goals.Find(goalId));
                _db.SaveChanges();
        }

        public List<Goals> GetAllGoals()
        {
            return _db.Goals.ToList();

        }

        public Goals GetGoalByClubId(int goalId, int clubId)
        {
            return _db.Goals.FirstOrDefault(g => g.Id == goalId && g.ClubId == clubId);

        }

        public Goals GetGoalByPlayerId(int goalId, int playerId)
        {
            return _db.Goals.FirstOrDefault(g => g.Id == goalId && g.ScorerId == playerId);

        }

        public void UpdateGoal(Goals goal)
        {
            _db.Goals.Update(goal);
            _db.SaveChanges();
        }
    }
}
