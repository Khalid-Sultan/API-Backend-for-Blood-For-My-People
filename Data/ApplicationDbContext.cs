using BloodDonation.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BloodDonation.Data
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Item> items { get; set; }

        public DbSet<DonationHistory> donationHistories { get; set; }
        public DbSet<Donor> donors { get; set; }
        public DbSet<Recepient> recepients { get; set; }
        public DbSet<Report> reports { get; set; }
        public DbSet<User> users { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<User>()
                .HasOne(s => s.donor)
                .WithOne(s => s.user)
                .OnDelete(DeleteBehavior.Cascade);
            builder.Entity<User>()
                .HasOne(s => s.recepient)
                .WithOne(s => s.user)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Donor>()
                .HasOne(s => s.user)
                .WithOne(s => s.donor)
                .OnDelete(DeleteBehavior.Cascade);
            builder.Entity<Recepient>()
                .HasOne(s => s.user)
                .WithOne(s => s.recepient)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }


}
