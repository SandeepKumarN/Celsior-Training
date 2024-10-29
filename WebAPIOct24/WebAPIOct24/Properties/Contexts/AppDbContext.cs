using Microsoft.EntityFrameworkCore;
using WebAPIOct24.Models;

namespace WebAPIOct24.Properties.Contexts
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
            .HasKey(b => new { b.EmployeeId, b.EventId });

            modelBuilder.Entity<Booking>()
            .HasOne(eb => eb.Employee)
            .WithMany(e => e.Booking)
            .HasForeignKey(eb => eb.Employee.Id);

            modelBuilder.Entity<Booking>()
             .HasOne(eb => eb.Event)
             .WithMany(e => e.Bookings)
             .HasForeignKey(eb => eb.EventId);
            

        }

    }
}
