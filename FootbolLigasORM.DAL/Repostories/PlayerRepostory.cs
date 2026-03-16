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
    public class PlayerRepostory : IPlayerRepostory
    {
        private readonly AppDbContext _db;
        public PlayerRepostory(AppDbContext db)
        {
            _db = db;
        }
        public void AddPlayer(Players player)
        {
            _db.Players.Add(player);
                _db.SaveChanges();
        }

        public void DeletePlayer(int playerId)
        {
            _db.Players.Remove(_db.Players.Find(playerId));
            _db.SaveChanges();
        }

        public List<Players> GetAllPlayers()
        {
            return _db.Players.ToList();
        }

        public Players GetPlayerByClubId(int playerId, int clubId)
        {
            return _db.Players.Where(p => p.ClubId == clubId && p.Id == playerId).FirstOrDefault();
        }

        public void UpdatePlayer(Players player)
        {
            _db.Players.Update(player);
            _db.SaveChanges();

        }
    }
}
