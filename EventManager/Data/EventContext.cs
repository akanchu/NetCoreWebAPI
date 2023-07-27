using EventManager.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EventManager.Data
{
    public class EventContext : IdentityDbContext<User>
    {
        public EventContext(DbContextOptions<EventContext> options) : base(options) { }
        public DbSet<Country> Country { get; set; }
        public DbSet<EventType> EventType { get; set; }
        public DbSet<EventManager> EventManager { get; set; }
        public DbSet<KOL> KOL { get; set; }
        public DbSet<Event> Event { get; set; }
        public DbSet<BusinessOwner> BusinessOwner { get; set; }
        public DbSet<KOLEvent> KOLEvent { get; set; }

        public DbSet<EventManagement> EventManagement { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer();
            base.OnConfiguring(optionsBuilder);
        }
    }
}
