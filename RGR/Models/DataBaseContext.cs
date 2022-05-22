using System;
using System.IO;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace RGR.Models.Database
{
    public partial class DatabaseContext : DbContext
    {
        public DatabaseContext()
        {
        }

        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BaseballPlayer> Players { get; set; } = null!;
        public virtual DbSet<BaseballTeam> Teams { get; set; } = null!;
        public virtual DbSet<City> Cities { get; set; } = null!;
        public virtual DbSet<StatisticOfCareerAllTime> StatisticOfCareerAllTime { get; set; } = null!;
        public virtual DbSet<StatisticOfMatches> StatisticOfMatches { get; set; } = null!;
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

                entity.ToTable("Player");

                entity.Property(e => e.Name)
                    .HasColumnType("STRING")
                    .HasColumnName("NAME");

                entity.Property(e => e.Born)
                    .HasColumnType("STRING")
                    .HasColumnName("Born");

                entity.Property(e => e.Age)
                    .HasColumnType("INTEGER")
                    .HasColumnName("Age");

                entity.Property(e => e.Bats)
                    .HasColumnType("STRING")
                    .HasColumnName("Bats");

            });

            modelBuilder.Entity<BaseballTeam>(entity =>
            {
                entity.ToTable("Teams");

                entity.Property(e => e.Name)
                .HasColumnType("STRING")
                .HasColumnName("Name");


                entity.Property(e => e.Record)
                    .HasColumnType("STRING")
                    .HasColumnName("Record");

                entity.Property(e => e.PlayoffAppearances)
                   .HasColumnType("STRING")
                   .HasColumnName("Playoff Appearances");

                entity.Property(e => e.Seasons)
                   .HasColumnType("INTEGER")
                   .HasColumnName("Seasons");


            });

            modelBuilder.Entity<City>(entity =>
            {
                entity.ToTable("City");


                entity.Property(e => e.Name)
                    .HasColumnType("STRING")
                    .HasColumnName("Name");
            });

            modelBuilder.Entity<StatisticOfCareerAllTime>(entity =>
            {
                entity.ToTable("StatisticOfCareerAllTime");

                entity.Property(e => e.NameTeam)
                .HasColumnType("STRING")
                .HasColumnName("NameTeam");


                entity.Property(e => e.War)
                    .HasColumnType("DOUBLE")
                    .HasColumnName("WAR");


                entity.Property(e => e.War)
                    .HasColumnType("DOUBLE")
                    .HasColumnName("WAR");

                entity.Property(e => e.AB)
                   .HasColumnType("INTEGER")
                   .HasColumnName("AB");

                entity.Property(e => e.H)
                   .HasColumnType("INTEGER")
                   .HasColumnName("H");

                entity.Property(e => e.HR)
                   .HasColumnType("INTEGER")
                   .HasColumnName("HR");
            });


            modelBuilder.Entity<StatisticOfMatches>(entity =>
            {
                entity.ToTable("StatisticOfMatches");

                entity.Property(e => e.Date)
                .HasColumnType("STRING")
                .HasColumnName("Date");

                entity.Property(e => e.Venue)
               .HasColumnType("STRING")
               .HasColumnName("Venue");

                entity.Property(e => e.Points)
               .HasColumnType("INTEGER")
               .HasColumnName("Points");

                entity.Property(e => e.GameDuration)
               .HasColumnType("STRING")
               .HasColumnName("GameDuration");
            });


            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}