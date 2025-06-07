using Microsoft.EntityFrameworkCore;
using VehicleModels.Models;

namespace DataContext
{
    public class VehicleDbContext : DbContext
    {
        public DbSet<Electricity> Electricities { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<County> Counties { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<CensusTract> CensusTracts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-8BCOFKO\\SQLEXPRESS;Initial Catalog =ElectricVehicles;Integrated Security=True;TrustServerCertificate=True;Pooling=False;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Vehicle>()
                .HasOne(e => e.Electricity)
                .WithMany(v => v.Vehicles)
                .HasForeignKey(e => e.ElectricityId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Vehicle>()
                .HasOne(s => s.State)
                .WithMany(v => v.Vehicles)
                .HasForeignKey(s => s.StateId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<State>()
               .HasMany(c => c.Counties)
               .WithOne(s => s.State)
               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<County>()
               .HasMany(c => c.Cities)
               .WithOne(c => c.County)
               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<City>()
               .HasMany(c => c.CensusTracts)
               .WithOne(c => c.City)
               .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(modelBuilder);
        }
    }
}
