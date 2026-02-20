using Microsoft.EntityFrameworkCore;
using SaaS_Diver.Models;

namespace SaaS_Diver.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        // Tablas de la base de datos
        public DbSet<SubscriptionPlan> SubscriptionPlans { get; set; }
        public DbSet<Subscriber> Subscribers { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var fecha = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc);

            modelBuilder.Entity<SubscriptionPlan>().HasData(
                new SubscriptionPlan { Id = 1, Name = "Basic Plan", Price = 9.99m, BillingCycle = "Monthly", IsActive = true },
                new SubscriptionPlan { Id = 2, Name = "Premium Plan", Price = 99.90m, BillingCycle = "Annual", IsActive = true }
            );

            modelBuilder.Entity<Subscriber>().HasData(
                new Subscriber
                {
                    Id = 1,
                    Name = "Juan Perez",
                    TaxId = "77665544",
                    Email = "juan.perez@email.com",
                    RegistrationDate = fecha
                }
            );

            modelBuilder.Entity<Subscription>().HasData(
                new Subscription
                {
                    Id = 1,
                    SubscriberId = 1,
                    SubscriptionPlanId = 2,
                    StartDate = fecha,
                    Status = "Active"
                }
            );
        }
    }
}
