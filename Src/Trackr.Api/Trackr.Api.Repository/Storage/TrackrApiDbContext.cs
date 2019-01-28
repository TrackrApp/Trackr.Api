using Microsoft.EntityFrameworkCore;

namespace Trackr.Api.Model.Storage
{
    public class TrackrApiDbContext : DbContext
    {
        public DbSet<ChampionshipState> Championships { get; set; }

        public DbSet<RaceState> Races { get; set; }

        public DbSet<SessionState> Sessions { get; set; }

        public TrackrApiDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ConfigureChampionships(modelBuilder);
            ConfigureRaces(modelBuilder);
        }

        private void ConfigureChampionships(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<ChampionshipState>()
                .HasKey(c => c.Id);

            modelBuilder
                .Entity<ChampionshipState>()
                .HasMany(c => c.Races);
        }

        private void ConfigureRaces(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<RaceState>()
                .HasKey(r => r.Id);

            modelBuilder
                .Entity<RaceState>()
                .HasMany(r => r.Sessions);
        }

        private void ConfigureSessions(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<SessionState>()
                .HasKey(s => s.Id);
        }
    }
}