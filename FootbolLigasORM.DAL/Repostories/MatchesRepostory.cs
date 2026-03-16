using FootbolLigasORM.DAL.Context;
using FootbolLigasORM.DAL.Entities;
using FootbolLigasORM.DAL.Interfaces;


namespace FootbolLigasORM.DAL.Repostories
{
    public class MatchesRepostory : IMatchesRepostory
    {
        private readonly AppDbContext _db;
        public MatchesRepostory(AppDbContext db)
        {
            _db = db;
        }
        public void AddMatch(Matches match)
        {
            _db.Matches.Add(match);
            _db.SaveChanges();

        }

        public void DeleteMatch(int matchId)
        {
            _db.Matches.Remove(_db.Matches.Find(matchId));
            _db.SaveChanges();
        }

        public List<Matches> GetAllMatches()
        {
            return _db.Matches.ToList();


        }

        public Matches GetMatchById(int matchId)
        {
            return _db.Matches.FirstOrDefault(m => m.Id == matchId);
        }

        public void UpdateMatch(Matches match)
        {
            _db.Matches.Update(match);
            _db.SaveChanges();
        }
    }
}
