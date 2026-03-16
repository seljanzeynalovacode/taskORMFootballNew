using FootbolLigasORM.DAL.Entities;
using FootbolLigasORM.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootbolLigasORM.BLL.Sevices
{
    public class ClubService
    {
        /*
         private readonly IEventRepostory _eventRepository;

        public EventService(IEventRepostory eventRepository)
        {
            _eventRepository = eventRepository;
        }
        */
        private readonly IClubsRepostory _clubRepostory;
        public ClubService(IClubsRepostory clubRepostory)
        {
            _clubRepostory = clubRepostory;
        }
        public void AddClub(Clubs club)
        {
            if (club == null)
            {
                throw new ArgumentNullException(nameof(club), "Club cannot be null.");
            }
            if (string.IsNullOrWhiteSpace(club.Name))
            {
                throw new ArgumentException("Club name cannot be empty.", nameof(club.Name));
            }
            if (club.Founded > DateTime.Now)
            {
                throw new ArgumentException("Founded date cannot be in the future.", nameof(club.Founded));
            }
            if (string.IsNullOrWhiteSpace(club.City))
            {
                throw new ArgumentException("City cannot be empty.", nameof(club.City));
            }
            if (string.IsNullOrWhiteSpace(club.Manager))
            {
                throw new ArgumentException("Manager cannot be empty.", nameof(club.Manager));
            }
            if (club.PerformanceRate < 0 || club.PerformanceRate > 100)
            {
                throw new ArgumentOutOfRangeException(nameof(club.PerformanceRate), "Performance rate must be between 0 and 100.");
            }

            _clubRepostory.AddClub(club);
        }
        public void UpdateClub(Clubs club)
        {
            if (club == null)
            {
                throw new ArgumentNullException(nameof(club), "Club cannot be null.");
            }
            if (string.IsNullOrWhiteSpace(club.Name))
            {
                throw new ArgumentException("Club name cannot be empty.", nameof(club.Name));
            }
            if (club.Founded > DateTime.Now)
            {
                throw new ArgumentException("Founded date cannot be in the future.", nameof(club.Founded));
            }
            if (string.IsNullOrWhiteSpace(club.City))
            {
                throw new ArgumentException("City cannot be empty.", nameof(club.City));
            }
            if (string.IsNullOrWhiteSpace(club.Manager))
            {
                throw new ArgumentException("Manager cannot be empty.", nameof(club.Manager));
            }
            if (club.PerformanceRate < 0 || club.PerformanceRate > 100)
            {
                throw new ArgumentOutOfRangeException(nameof(club.PerformanceRate), "Performance rate must be between 0 and 100.");
            }
            _clubRepostory.UpdateClub(club);

        }
        public void DeleteClub(int clubId)
        {
            if (clubId <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(clubId), "Club ID must be a positive integer.");
            }
            if (_clubRepostory.GetClubById(clubId) == null)
            {
                throw new ArgumentException("Club with the specified ID does not exist.", nameof(clubId));
            }
            if (_clubRepostory.GetClubById(clubId).Players != null && _clubRepostory.GetClubById(clubId).Players.Count > 0)
            {
                throw new InvalidOperationException("Cannot delete a club that has players. Please remove the players first.");
            }
            if (_clubRepostory.GetClubById(clubId).HomeMatches != null && _clubRepostory.GetClubById(clubId).HomeMatches.Count > 0)
            {
                throw new InvalidOperationException("Cannot delete a club that has home matches. Please remove the matches first.");
            }
            if (_clubRepostory.GetClubById(clubId).AwayMatches != null && _clubRepostory.GetClubById(clubId).AwayMatches.Count > 0)
            {
                throw new InvalidOperationException("Cannot delete a club that has away matches. Please remove the matches first.");
            }
            if (_clubRepostory.GetClubById(clubId).Stadiums != null && _clubRepostory.GetClubById(clubId).Stadiums.Count > 0)
            {
                throw new InvalidOperationException("Cannot delete a club that has associated stadiums. Please remove the stadium associations first.");
            }

            _clubRepostory.DeleteClub(clubId);
        }
        public Clubs GetClubById(int clubId)
        {
            if (clubId <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(clubId), "Club ID must be a positive integer.");
            }
            var club = _clubRepostory.GetClubById(clubId);
            if (club == null)
            {
                throw new ArgumentException("Club with the specified ID does not exist.", nameof(clubId));
            }
            if (club.Players != null && club.Players.Count > 0)
            {
                throw new InvalidOperationException("Cannot retrieve a club that has players. Please remove the players first.");
            }
            return club;
        }
        public List<Clubs> GetAllClubs()
        {
            var clubs = _clubRepostory.GetAllClubs();
            if (clubs == null || clubs.Count == 0)
            {
                throw new InvalidOperationException("No clubs found in the database.");
            }
            
            return clubs;
        }
         
    }
}
