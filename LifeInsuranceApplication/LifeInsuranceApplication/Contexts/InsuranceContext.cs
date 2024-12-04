using LifeInsuranceApplication.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;

namespace LifeInsuranceApplication.Contexts
{
    public class InsuranceContext : DbContext
    {
        public InsuranceContext(DbContextOptions contextOptions) : base(contextOptions)
        {}

        public DbSet<User> Users { get; set; }
        public DbSet<Claim> Claims { get; set; }
        public DbSet<Policy> Policies { get; set; }
        public DbSet<ClaimType> ClaimTypes { get; set; }

        override protected void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Claim>()
                .HasOne(c => c.Policy)
                .WithMany(p => p.Claims)
                .HasForeignKey(c => c.PolicyId);

            modelBuilder.Entity<Claim>()
                .HasOne(c => c.ClaimType)
                .WithMany(c => c.Claims)
                .HasForeignKey(c => c.ClaimTypeId);
        }
    }
}
