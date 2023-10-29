using Microsoft.EntityFrameworkCore;

namespace EventTracingBackend.BusinessLogic
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }

        public DbSet<Event> EventList { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Participant> Participants { get; set; }
        public DbSet<EventParticipant> EventParticipants { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EventParticipant>()
                .HasKey(ep => new { ep.ParticipantId, ep.EventId });
            modelBuilder.Entity<EventParticipant>()
                .HasOne(e => e.Event)
                .WithMany(ep => ep.EventParticipants)
                .HasForeignKey(c => c.EventId);
            modelBuilder.Entity<EventParticipant>()
                .HasOne(p => p.Participant)
                .WithMany(ep => ep.EventParticipants)
                .HasForeignKey(c => c.ParticipantId);
        }
    }
}
