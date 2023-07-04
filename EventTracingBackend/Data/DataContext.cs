using EventTracingBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace EventTracingBackend.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }

        public DbSet<Event> EventList { get; set; }
    }
}
