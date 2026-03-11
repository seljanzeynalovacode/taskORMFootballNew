using System;
using Microsoft.EntityFrameworkCore;
using FootbolLigasORM.DAL.Entities;

namespace FootbolLigasORM.DAL.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        // Parameterless constructor for design tools (optional)
        public AppDbContext()
        {
        }

        // DbSets
        public DbSet<Clubs> Clubs { get; set; } = null!;
        public DbSet<Players> Players { get; set; } = null!;
        public DbSet<Stadiums> Stadiums { get; set; } = null!;
        public DbSet<Matches> Matches { get; set; } = null!;
        public DbSet<Goals> Goals { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // Default to LocalDB if no configuration provided. Replace with your SQL Server connection string in production.
                optionsBuilder.UseSqlServer("Data Source=SELJAN-ASUS-LAP\\SQLEXPRESS;Initial Catalog=FulbolLigasORM;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");
            }

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // BaseEntity.Id is the key for all entities by convention.

            // Clubs
            modelBuilder.Entity<Clubs>(entity =>
            {
                entity.ToTable("Clubs");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(200);
                entity.HasMany(e => e.Players).WithOne(p => p.Club).HasForeignKey(p => p.ClubId).OnDelete(DeleteBehavior.Cascade);
                entity.HasMany(e => e.Stadiums).WithOne(s => s.Club).HasForeignKey(s => s.ClubId).OnDelete(DeleteBehavior.SetNull);
                // Home/Away Matches configured below
            });

            // Players
            modelBuilder.Entity<Players>(entity =>
            {
                entity.ToTable("Players");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.FirstName).IsRequired().HasMaxLength(100);
                entity.Property(e => e.LastName).IsRequired().HasMaxLength(100);
                entity.HasMany(p => p.Goals).WithOne(g => g.Scorer).HasForeignKey(g => g.ScorerId).OnDelete(DeleteBehavior.Cascade);
            });

            // Stadiums
            modelBuilder.Entity<Stadiums>(entity =>
            {
                entity.ToTable("Stadiums");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(200);
                entity.HasMany(s => s.Matches).WithOne(m => m.Stadium).HasForeignKey(m => m.StadiumId).OnDelete(DeleteBehavior.SetNull);
            });

            // Matches
            modelBuilder.Entity<Matches>(entity =>
            {
                entity.ToTable("Matches");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Title).HasMaxLength(250);

                // Configure two relationships to Clubs for FirstClub and SecondClub (Home/Away)
                entity.HasOne(m => m.FirstClub)
                    .WithMany(c => c.HomeMatches)
                    .HasForeignKey(m => m.FirstClubId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(m => m.SecondClub)
                    .WithMany(c => c.AwayMatches)
                    .HasForeignKey(m => m.SecondClubId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            // Goals
            modelBuilder.Entity<Goals>(entity =>
            {
                entity.ToTable("Goals");
                entity.HasKey(e => e.Id);
                entity.HasOne(g => g.Match).WithMany().HasForeignKey(g => g.MatchId).OnDelete(DeleteBehavior.Cascade);
                entity.HasOne(g => g.Club).WithMany().HasForeignKey(g => g.ClubId).OnDelete(DeleteBehavior.Restrict);
                // Scorer relationship configured in Players mapping to avoid duplication
            });

            base.OnModelCreating(modelBuilder);
        }

        // Helper to apply pending migrations and create/update the database
        public void MigrateDatabase()
        {
            Database.Migrate();
        }
    }
}
