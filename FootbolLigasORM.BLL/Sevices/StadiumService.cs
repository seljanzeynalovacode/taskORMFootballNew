using FootbolLigasORM.DAL.Entities;
using FootbolLigasORM.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootbolLigasORM.BLL.Sevices
{
    public class StadiumService
    {
        private readonly IStadiumRepostory _stadiumRepostory;
        public StadiumService(IStadiumRepostory stadiumRepostory)
        {
            _stadiumRepostory = stadiumRepostory;
        }
        public void AddStadium(Stadiums stadium)
        {
            if (stadium == null)
            {
                throw new ArgumentNullException(nameof(stadium), "Stadium cannot be null.");
            }
            if (string.IsNullOrWhiteSpace(stadium.Name))
            {
                throw new ArgumentException("Stadium name cannot be empty.", nameof(stadium.Name));
            }
            if (string.IsNullOrWhiteSpace(stadium.City))
            {
                throw new ArgumentException("Location cannot be empty.", nameof(stadium.City));
            }
            if (stadium.Capacity <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(stadium.Capacity), "Capacity must be a positive integer.");
            }
            _stadiumRepostory.AddStadium(stadium);
        }
        public void UpdateStadium(Stadiums stadium)
        {
            if (stadium == null)
            {
                throw new ArgumentNullException(nameof(stadium), "Stadium cannot be null.");
            }
            if (string.IsNullOrWhiteSpace(stadium.Name))
            {
                throw new ArgumentException("Stadium name cannot be empty.", nameof(stadium.Name));
            }
            if (string.IsNullOrWhiteSpace(stadium.City))
            {
                throw new ArgumentException("Location cannot be empty.", nameof(stadium.City));
            }
            if (stadium.Capacity <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(stadium.Capacity), "Capacity must be a positive integer.");
            }
            _stadiumRepostory.UpdateStadium(stadium);
        }
        public void DeleteStadium(int stadiumId)
        {
            if (stadiumId <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(stadiumId), "Stadium ID must be a positive integer.");
            }
            if (_stadiumRepostory.GetStadiumById(stadiumId) == null)
            {
                throw new ArgumentException("Stadium with the specified ID does not exist.", nameof(stadiumId));
            }
            _stadiumRepostory.DeleteStadium(stadiumId);
        }
        public List<Stadiums> GetAllStadiums()
        {
            if(_stadiumRepostory.GetAllStadiums() == null || !_stadiumRepostory.GetAllStadiums().Any())
            {
                throw new InvalidOperationException("No stadiums found.");
            }
            if (_stadiumRepostory.GetAllStadiums().Count > 1000)
            {
                throw new InvalidOperationException("Too many stadiums found. Consider implementing pagination.");
            }
            if (_stadiumRepostory.GetAllStadiums().Any(s => s.Capacity <= 0))
            {
                throw new InvalidOperationException("One or more stadiums have invalid capacity values.");
            }
            if (_stadiumRepostory.GetAllStadiums().Any(s => string.IsNullOrWhiteSpace(s.Name)))
            {
                throw new InvalidOperationException("One or more stadiums have invalid name values.");
            }
            return _stadiumRepostory.GetAllStadiums();
        }
    }
}
