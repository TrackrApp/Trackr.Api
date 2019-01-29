using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Trackr.Api.Shared.Domain;

namespace Trackr.Api.Model.Storage
{
    public class TrackrApiDbContext : DbContext
    {
        public DbSet<ChampionshipState> Championships { get; set; }

        public DbSet<EventState> Events { get; set; }

        public DbSet<SessionState> Sessions { get; set; }

        public DbSet<ResultState> Results { get; set; }

        public TrackrApiDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ConfigureChampionships(modelBuilder);
            ConfigureEvents(modelBuilder);
            ConfigureSessions(modelBuilder);
            ConfigureResults(modelBuilder);
        }

        private void ConfigureChampionships(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<ChampionshipState>()
                .HasKey(c => c.Id);

            modelBuilder
                .Entity<ChampionshipState>()
                .HasMany(c => c.Events);
        }

        private void ConfigureEvents(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<EventState>()
                .HasKey(r => r.Id);

            modelBuilder
                .Entity<EventState>()
                .HasMany(r => r.Sessions);
        }

        private void ConfigureSessions(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<SessionState>()
                .HasKey(s => s.Id);

            modelBuilder
                .Entity<SessionState>()
                .HasMany(s => s.Results);

            modelBuilder
                .Entity<SessionState>()
                .Property(s => s.SessionType)
                    .HasConversion(new EnumToStringConverter<SessionType>());
        }

        private void ConfigureResults(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<ResultState>()
                .HasKey(s => s.Id);
        }
    }
}