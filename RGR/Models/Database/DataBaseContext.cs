using System;
using System.IO;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace RGR.Models.Database
{
    public partial class DataBaseContext : DbContext
    {
        public DataBaseContext()
        {
        }

        public DataBaseContext(DbContextOptions<DataBaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BaseballPlayer> BaseballPlayers { get; set; }
        public virtual DbSet<BaseballTeam> BaseballTeams { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<StatisticOfCareerAllTime> StatisticOfCareerAllTimes { get; set; }
        public virtual DbSet<StatisticOfMatches> StatisticOfMatches { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite(
                "Data Source=" + Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName
                 + "\\Assets\\DataBase.db");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BaseballPlayer>(entity =>
            {
                entity.HasKey(e => e.ProperName);

                entity.ToTable("Baseball Player");

                entity.Property(e => e.ProperName).HasColumnName("Proper Name");

                entity.Property(e => e.Bats).IsRequired();

                entity.Property(e => e.TeamSName)
                    .IsRequired()
                    .HasColumnName("Team`s name");

                entity.HasOne(d => d.TeamSNameNavigation)
                    .WithMany(p => p.BaseballPlayers)
                    .HasForeignKey(d => d.TeamSName)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<BaseballTeam>(entity =>
            {
                entity.HasKey(e => e.ProperName);

                entity.ToTable("Baseball Team");

                entity.Property(e => e.ProperName).HasColumnName("Proper Name");

                entity.Property(e => e.PlayoffAppearances).HasColumnName("Playoff Appearances");

                entity.HasOne(d => d.CityNavigation)
                    .WithMany(p => p.BaseballTeams)
                    .HasForeignKey(d => d.City);
            });

            modelBuilder.Entity<City>(entity =>
            {
                entity.HasKey(e => e.NameOfTheCity);

                entity.ToTable("City");

                entity.Property(e => e.NameOfTheCity).HasColumnName("Name of the city");

                entity.Property(e => e.TeamSName).HasColumnName("Team`s name");

                entity.HasOne(d => d.TeamSNameNavigation)
                    .WithMany(p => p.Cities)
                    .HasForeignKey(d => d.TeamSName);
            });

            modelBuilder.Entity<StatisticOfCareerAllTime>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Statistic of career all time");

                entity.Property(e => e.Ab).HasColumnName("AB");

                entity.Property(e => e.Hr).HasColumnName("HR");

                entity.Property(e => e.PlayerSName)
                    .IsRequired()
                    .HasColumnName("Player`s Name");

                entity.Property(e => e.TeamSName).HasColumnName("Team`s Name");

                entity.Property(e => e.War)
                    .HasColumnType("DOUBLE")
                    .HasColumnName("WAR");

                entity.HasOne(d => d.PlayerSNameNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.PlayerSName)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<StatisticOfMatches>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Statistic of matches");

                entity.Property(e => e.Date).IsRequired();

                entity.Property(e => e.GameDuration).HasColumnName("Game Duration");

                entity.Property(e => e.TeamSName)
                    .IsRequired()
                    .HasColumnName("Team`s name");

                entity.HasOne(d => d.TeamSNameNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.TeamSName)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
