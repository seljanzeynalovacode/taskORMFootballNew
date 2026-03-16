using FootbolLigasORM.DAL.Entities;
using FootbolLigasORM.DAL.Interfaces;


namespace FootbolLigasORM.BLL.Sevices
{
    public class GoalService
    {

        private readonly IGoalsRepostory _goalRepostory;
        public GoalService(IGoalsRepostory goalRepostory)
        {
            _goalRepostory = goalRepostory;
        }
        public void AddGoal(Goals goal)
        {
            if (goal == null)
            {
                throw new ArgumentNullException(nameof(goal), "Goal cannot be null.");
            }
            if (goal.ScorerId <= 0)
            {
                throw new ArgumentException("Scorer ID must be a positive integer.", nameof(goal.ScorerId));
            }
            if (goal.ClubId <= 0)
            {
                throw new ArgumentException("Club ID must be a positive integer.", nameof(goal.ClubId));
            }
            if (goal.Minute < 0 || goal.Minute > 120)
            {
                throw new ArgumentOutOfRangeException(nameof(goal.Minute), "Minute must be between 0 and 120.");
            }
            _goalRepostory.AddGoal(goal);
        }
        public void UpdateGoal(Goals goal)
        {
            if (goal == null)
            {
                throw new ArgumentNullException(nameof(goal), "Goal cannot be null.");
            }
            if (goal.ScorerId <= 0)
            {
                throw new ArgumentException("Scorer ID must be a positive integer.", nameof(goal.ScorerId));
            }
            if (goal.ClubId <= 0)
            {
                throw new ArgumentException("Club ID must be a positive integer.", nameof(goal.ClubId));
            }
            if (goal.Minute < 0 || goal.Minute > 120)
            {
                throw new ArgumentOutOfRangeException(nameof(goal.Minute), "Minute must be between 0 and 120.");
            }
            _goalRepostory.UpdateGoal(goal);
        }
        public void DeleteGoal(int goalId)
        {
            if (goalId <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(goalId), "Goal ID must be a positive integer.");
            }
            if (_goalRepostory.GetAllGoals().FirstOrDefault(g => g.Id == goalId) == null)
            {
                throw new ArgumentException("Goal with the specified ID does not exist.", nameof(goalId));
            }
            if (_goalRepostory.GetAllGoals().FirstOrDefault(g => g.Id == goalId).Minute < 0 || _goalRepostory.GetAllGoals().FirstOrDefault(g => g.Id == goalId).Minute > 120)
            {
                throw new ArgumentOutOfRangeException(nameof(goalId), "Goal minute must be between 0 and 120.");
            }
            if (_goalRepostory.GetAllGoals().FirstOrDefault(g => g.Id == goalId).ScorerId <= 0)
            {
                throw new ArgumentException("Scorer ID must be a positive integer.", nameof(goalId));
            }
            _goalRepostory.DeleteGoal(goalId);
        }
        public List<Goals> GetAllGoals()
        {
            if (_goalRepostory.GetAllGoals() == null || !_goalRepostory.GetAllGoals().Any())
            {
                throw new InvalidOperationException("No goals found.");
            }
            if (_goalRepostory.GetAllGoals().Any(g => g.Minute < 0 || g.Minute > 120))
            {
                throw new InvalidOperationException("One or more goals have invalid minute values. Minute must be between 0 and 120.");
            }
            if (_goalRepostory.GetAllGoals().Any(g => g.ScorerId <= 0))
            {
                throw new InvalidOperationException("One or more goals have invalid scorer IDs. Scorer ID must be a positive integer.");
            }

            return _goalRepostory.GetAllGoals();
        }
        public Goals GetGoalByClubId(int goalId, int clubId)
        {
            if (goalId <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(goalId), "Goal ID must be a positive integer.");
            }
            if (clubId <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(clubId), "Club ID must be a positive integer.");
            }
            var goal = _goalRepostory.GetGoalByClubId(goalId, clubId);
            if (goal == null)
            {
                throw new ArgumentException("Goal with the specified ID and Club ID does not exist.", nameof(goalId));
            }
            if (goal.Minute < 0 || goal.Minute > 120)
            {
                throw new InvalidOperationException("Goal minute must be between 0 and 120.");
            }
            if (goal.ScorerId <= 0)
            {
                throw new InvalidOperationException("Scorer ID must be a positive integer.");
            }
            return goal;
        }
    }
}
