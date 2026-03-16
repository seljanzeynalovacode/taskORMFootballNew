using FootbolLigasORM.DAL.Entities;
using FootbolLigasORM.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootbolLigasORM.BLL.Sevices
{
    public class PlayerService

    {
        private readonly IPlayerRepostory _playerRepostory;
        public PlayerService(IPlayerRepostory playerRepostory)
        {
            _playerRepostory = playerRepostory;
        }
        public void AddPlayer(Players player)
        {
            if (player == null)
            {
                throw new ArgumentNullException(nameof(player), "Player cannot be null.");
            }
            if (string.IsNullOrWhiteSpace(player.FirstName))
            {
                throw new ArgumentException("Player name cannot be empty.", nameof(player.FirstName));
            }
            if (string.IsNullOrEmpty(player.LastName))
            {
                throw new ArgumentException("Player last name cannot be empty.", nameof(player.LastName));
            }
            if (player.ClubId <= 0)
            {
                throw new ArgumentException("Club ID must be a positive integer.", nameof(player.ClubId));
            }
            _playerRepostory.AddPlayer(player);
        }
        public void UpdatePlayer(Players player)
        {
            if (player == null)
            {
                throw new ArgumentNullException(nameof(player), "Player cannot be null.");
            }
            if (string.IsNullOrWhiteSpace(player.FirstName))
            {
                throw new ArgumentException("Player name cannot be empty.", nameof(player.FirstName));
            }
            if (string.IsNullOrEmpty(player.LastName))
            {
                throw new ArgumentException("Player last name cannot be empty.", nameof(player.LastName));
            }

            if (player.ClubId <= 0)
            {
                throw new ArgumentException("Club ID must be a positive integer.", nameof(player.ClubId));
            }
            _playerRepostory.UpdatePlayer(player);
        }
        public void DeletePlayer(int playerId)
        {
            if (playerId <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(playerId), "Player ID must be a positive integer.");
            }
            if (_playerRepostory.GetPlayerByClubId(playerId, 0) == null)
            {
                throw new ArgumentException("Player with the specified ID does not exist.", nameof(playerId));
            }
            _playerRepostory.DeletePlayer(playerId);
        }
        public List<Players> GetAllPlayers()
        {
            if (_playerRepostory.GetAllPlayers() == null || !_playerRepostory.GetAllPlayers().Any())
            {
                throw new InvalidOperationException("No players found.");
            }
            return _playerRepostory.GetAllPlayers();
        }
        public Players GetPlayerByClubId(int playerId, int clubId)
        {
            if (playerId <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(playerId), "Player ID must be a positive integer.");
            }
            if (clubId <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(clubId), "Club ID must be a positive integer.");
            }
            var player = _playerRepostory.GetPlayerByClubId(playerId, clubId);
            if (player == null)
            {
                throw new ArgumentException("Player with the specified ID and club ID does not exist.", nameof(playerId));
            }
            return player;
        }
    }
}
