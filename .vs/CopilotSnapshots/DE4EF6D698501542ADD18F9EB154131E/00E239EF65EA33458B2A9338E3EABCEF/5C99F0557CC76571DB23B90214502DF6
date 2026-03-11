using System;
using System.Linq;
using FootbolLigasORM.DAL.Context;
using FootbolLigasORM.DAL.Repostory;
using FootbolLigasORM.DAL.Entities;

namespace FootbolLigasORM.UI
{
    internal class MenuOperation
    {
        private readonly AppDbContext _context;
        private readonly ClubRepository _clubRepo;

        public MenuOperation()
        {
            _context = new AppDbContext();
            _clubRepo = new ClubRepository(_context);
        }

        public void Run()
        {
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("Football League - Main Menu");
                Console.WriteLine("1. List clubs");
                Console.WriteLine("2. View club details");
                Console.WriteLine("3. Create club");
                Console.WriteLine("4. Update club");
                Console.WriteLine("5. Delete club");
                Console.WriteLine("0. Exit");
                Console.Write("Select an option: ");

                var input = Console.ReadLine();
                switch (input)
                {
                    case "1": ListClubs(); break;
                    case "2": ViewClubDetails(); break;
                    case "3": CreateClub(); break;
                    case "4": UpdateClub(); break;
                    case "5": DeleteClub(); break;
                    case "0": return;
                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }
            }
        }

        private void ListClubs()
        {
            var clubs = _clubRepo.GetAllAsync().GetAwaiter().GetResult();
            if (clubs == null || clubs.Count ==0)
            {
                Console.WriteLine("No clubs found.");
                return;
            }

            Console.WriteLine("Clubs:");
            foreach (var c in clubs)
            {
                Console.WriteLine($"{c.Id}. {c.Name} ({c.City}) - Players: {c.Players?.Count ??0}");
            }
        }

        private void ViewClubDetails()
        {
            Console.Write("Enter club id: ");
            if (!int.TryParse(Console.ReadLine(), out var id))
            {
                Console.WriteLine("Invalid id.");
                return;
            }

            var club = _clubRepo.GetByIdAsync(id).GetAwaiter().GetResult();
            if (club == null)
            {
                Console.WriteLine("Club not found.");
                return;
            }

            Console.WriteLine($"Id: {club.Id}");
            Console.WriteLine($"Name: {club.Name}");
            Console.WriteLine($"City: {club.City}");
            Console.WriteLine($"Founded: {club.Founded:d}");
            Console.WriteLine($"Manager: {club.Manager}");
            Console.WriteLine($"Performance: {club.PerformanceRate}");
            Console.WriteLine("Players:");
            if (club.Players != null && club.Players.Any())
            {
                foreach (var p in club.Players)
                {
                    Console.WriteLine($"  {p.Id}. {p.FirstName} {p.LastName} - {p.Position} #{p.JerseyNumber}");
                }
            }
            else
            {
                Console.WriteLine("  No players.");
            }
        }

        private void CreateClub()
        {
            var club = new Clubs();
            Console.Write("Name: ");
            club.Name = Console.ReadLine() ?? string.Empty;
            Console.Write("City: ");
            club.City = Console.ReadLine() ?? string.Empty;
            Console.Write("Founded (yyyy): ");
            if (int.TryParse(Console.ReadLine(), out var year))
                club.Founded = new DateTime(year,1,1);
            else
                club.Founded = DateTime.UtcNow;
            Console.Write("Manager: ");
            club.Manager = Console.ReadLine() ?? string.Empty;
            Console.Write("Performance rate (0-100): ");
            if (int.TryParse(Console.ReadLine(), out var perf)) club.PerformanceRate = perf;

            var created = _clubRepo.CreateAsync(club).GetAwaiter().GetResult();
            Console.WriteLine($"Created club with id {created.Id}.");
        }

        private void UpdateClub()
        {
            Console.Write("Enter club id to update: ");
            if (!int.TryParse(Console.ReadLine(), out var id))
            {
                Console.WriteLine("Invalid id.");
                return;
            }

            var club = _clubRepo.GetByIdAsync(id).GetAwaiter().GetResult();
            if (club == null)
            {
                Console.WriteLine("Club not found.");
                return;
            }

            Console.Write($"Name ({club.Name}): ");
            var name = Console.ReadLine(); if (!string.IsNullOrWhiteSpace(name)) club.Name = name;
            Console.Write($"City ({club.City}): ");
            var city = Console.ReadLine(); if (!string.IsNullOrWhiteSpace(city)) club.City = city;
            Console.Write($"Manager ({club.Manager}): ");
            var manager = Console.ReadLine(); if (!string.IsNullOrWhiteSpace(manager)) club.Manager = manager;
            Console.Write($"Performance ({club.PerformanceRate}): ");
            var perfInput = Console.ReadLine(); if (int.TryParse(perfInput, out var perf)) club.PerformanceRate = perf;

            var ok = _clubRepo.UpdateAsync(club).GetAwaiter().GetResult();
            Console.WriteLine(ok ? "Club updated." : "Failed to update club.");
        }

        private void DeleteClub()
        {
            Console.Write("Enter club id to delete: ");
            if (!int.TryParse(Console.ReadLine(), out var id))
            {
                Console.WriteLine("Invalid id.");
                return;
            }

            var ok = _clubRepo.DeleteAsync(id).GetAwaiter().GetResult();
            Console.WriteLine(ok ? "Club deleted." : "Club not found.");
        }
    }
}
