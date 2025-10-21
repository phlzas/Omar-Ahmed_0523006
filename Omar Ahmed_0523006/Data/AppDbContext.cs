using Microsoft.EntityFrameworkCore;
using Omar_Ahmed_0523006.Data.Models;

namespace Omar_Ahmed_0523006.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Team> team {  get; set; }
       public DbSet<Coach> coaches { get; set; }
        public DbSet<player> player { get; set; }
        public DbSet<Compttion> compttion { get; set; }

        public DbSet<TeamCompttion> teamCompttions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TeamCompttion>().HasKey(o => new { o.CompttionId, o.TeamId });

            modelBuilder.Entity<Team>().HasData(
                new Team { City = "last", Name = "Manchester", Id= 1, CoachId = 1},
                new Team { City = "lastOflast", Name = "Man", Id = 2, CoachId = 2},
                new Team {City = "lastOfoflast", Name = "chester", Id = 3, CoachId = 3 },
                new Team { City = "lastofofoflast", Name = "misy", Id = 4, CoachId = 4 }
                );
            modelBuilder.Entity<Coach>().HasData(
                new Coach { Id = 1, Name = "omar", ExpYears = 2, Speclatation = "puching" },
                new Coach { Id = 2, Name = "omarAhmed", ExpYears = 32, Speclatation = "helping" },
                new Coach { Id = 3, Name = "omarAhmedSamy", ExpYears = 22, Speclatation = "Feeling" },
                new Coach { Id = 4, Name = "omarAghmedSamyMohamed", ExpYears = 67, Speclatation = "hitting" }
                );

            modelBuilder.Entity<player>().HasData(
                new player { Id = 1 , Age=42, FullName ="ahmed", Postion = "mid", TeamId = 1 },
                new player { Id = 2 , Age=60, FullName ="Salah", Postion = "Attaker", TeamId = 1 },
                new player { Id = 3 , Age=22, FullName ="ziad", Postion = "Defender", TeamId = 1 },
                new player { Id = 4 , Age=33, FullName ="Mohamed", Postion = "Defender", TeamId = 1 }
                );
            modelBuilder.Entity<Compttion>().HasData(
                new Compttion { Id = 1, DateComp = new DateTime (2005,10,22), Locatioon = "al_hdayk al_qopa", Titel = "WorldCup1" },
                new Compttion { Id = 2, DateComp = new DateTime (2005,1,22), Locatioon = "al_hdayk al_qopa", Titel = "WorldCup2" },
                new Compttion { Id = 3, DateComp = new DateTime (2005,11,22), Locatioon = "al_hdayk al_qopa", Titel = "WorldCup3" },
                new Compttion { Id = 4, DateComp = new DateTime (2005,12,22), Locatioon = "al_hdayk al_qopa", Titel = "WorldCup4" }
                );
            modelBuilder.Entity<TeamCompttion>().HasData(
                new TeamCompttion { CompttionId =  2 ,  TeamId = 1},
                new TeamCompttion { CompttionId =  4 ,  TeamId = 3},
                new TeamCompttion { CompttionId =  3 ,  TeamId = 2},
                new TeamCompttion { CompttionId =  1 ,  TeamId = 4}
                );  

        }

    }

}
