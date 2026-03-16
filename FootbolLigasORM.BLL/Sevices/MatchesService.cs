using FootbolLigasORM.DAL.Entities;
using FootbolLigasORM.DAL.Interfaces;


namespace FootbolLigasORM.BLL.Sevices
{
    public class MatchesService
    {
        private readonly IMatchesRepostory _matchesRepostory;
        public MatchesService(IMatchesRepostory matchesRepostory)
        {
            _matchesRepostory = matchesRepostory;
        }
        public void AddMatch(Matches match)
        {
            if (match == null)
            {
                throw new ArgumentNullException(nameof(match), "Match cannot be null.");
            }
            if (match.FirstClubId <= 0)
            {
                throw new ArgumentException("Home team ID must be a positive integer.", nameof(match.FirstClubId));
            }
            if (match.SecondClubId <= 0)
            {
                throw new ArgumentException("Away team ID must be a positive integer.", nameof(match.SecondClubId));
            }
            if (match.MatchDate < DateTime.Now)
            {
                throw new ArgumentException("Match date cannot be in the past.", nameof(match.MatchDate));
            }
            _matchesRepostory.AddMatch(match);
        }
        public void UpdateMatch(Matches match)
        {
            if (match == null)
            {
                throw new ArgumentNullException(nameof(match), "Match cannot be null.");
            }
            if (match.FirstClubId <= 0)
            {
                throw new ArgumentException("Home team ID must be a positive integer.", nameof(match.FirstClubId));
            }
            if (match.SecondClubId <= 0)
            {
                throw new ArgumentException("Away team ID must be a positive integer.", nameof(match.SecondClubId));
            }
            if (match.MatchDate < DateTime.Now)
            {
                throw new ArgumentException("Match date cannot be in the past.", nameof(match.MatchDate));
            }
            _matchesRepostory.UpdateMatch(match);
        }
        public void DeleteMatch(int matchId)
        {
            if (matchId <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(matchId), "Match ID must be a positive integer.");
            }
            if (_matchesRepostory.GetMatchById(matchId) == null)
            {
                throw new ArgumentException("Match with the specified ID does not exist.", nameof(matchId));
            }
            

            _matchesRepostory.DeleteMatch(matchId);
        }
        public Matches GetMatchById(int matchId)
        {
            if (matchId <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(matchId), "Match ID must be a positive integer.");
            }
            if (_matchesRepostory.GetMatchById(matchId) == null)
            {
                throw new ArgumentException("Match with the specified ID does not exist.", nameof(matchId));
            }
            
            return _matchesRepostory.GetMatchById(matchId);
        }
        public List<Matches> GetAllMatches()
        {
            if (_matchesRepostory.GetAllMatches() == null || !_matchesRepostory.GetAllMatches().Any())
            {
                throw new InvalidOperationException("No matches found.");
            }
            if (_matchesRepostory.GetAllMatches().Count > 1000)
            {
                throw new InvalidOperationException("Too many matches found. Please refine your search criteria.");
            }
            if (_matchesRepostory.GetAllMatches().Any(m => m.MatchDate < DateTime.Now))
            {
                throw new InvalidOperationException("Some matches have already occurred. Please filter by date.");
            }
            if (_matchesRepostory.GetAllMatches().Any(m => m.FirstClubId <= 0 || m.SecondClubId <= 0))
            {
                throw new InvalidOperationException("Some matches have invalid team IDs. Please check the data integrity.");
            }
            return _matchesRepostory.GetAllMatches();
        }
    }
}
