using EventBooking.Models;
using Microsoft.EntityFrameworkCore;

namespace EventBooking.Properties.Contexts
{
    public class AppDbContext : DbContext
    {
            public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
            public DbSet<Employee> Employees { get; set; }
            public DbSet<Event> Events { get; set; }
            public DbSet<Booking> Bookings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Booking>()
            .HasOne(b => b.Employee)
            .WithMany(e => e.Booking)
            .HasForeignKey(b => b.EmployeeId);

            // Event to Booking relationship
            modelBuilder.Entity<Booking>()
                .HasOne(b => b.Event)
                .WithMany(e => e.Bookings)
                .HasForeignKey(b => b.EventId);
        }

    }
}
