using FootbolLigasORM.DAL.Entities;


namespace FootbolLigasORM.DAL.Interfaces
{
    public interface IPlayerRepostory
    {
        public void AddPlayer(Players player);
        public void UpdatePlayer(Players player);
        public void DeletePlayer(int playerId);
        public Players GetPlayerByClubId(int playerId, int clubId);
        public List<Players> GetAllPlayers();
    }
}
