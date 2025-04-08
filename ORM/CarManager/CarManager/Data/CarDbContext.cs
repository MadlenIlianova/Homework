using CarManager.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarManager.Data
{
    public class CarDbContext : DbContext
    {
        public DbSet<Cars> Cars { get; set; }
        public DbSet<Engine>Engines { get; set; }
        public DbSet<Model>Models { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=DESKTOP-8BCOFKO\\SQLEXPRESS;Initial Catalog =CarManager;Integrated Security=True;TrustServerCertificate=True;Pooling=False;");
        }




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            DbSeeder.CarSeeder(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }
        public void CompareCars(int carId1,int carId2) 
        {
            var car1 = Cars.Include(c => c.Model).Include(c => c.Engine).FirstOrDefault(c=>c.Id==carId1);
            var car2 = Cars.Include(c => c.Model).Include(c => c.Engine).FirstOrDefault(c=>c.Id==carId2);
            int car1points = 0;
            int car2points = 0;
            if (car1.Seats > car2.Seats)
            {
                Console.WriteLine($"{car1.Brand} has more seats than {car2.Brand}.");
                car1points++;
            }
            else 
            {
                Console.WriteLine($"{car2.Brand} has more seats than {car1.Brand}");
                car2points++;
            }

            if (car1.Height > car2.Height)
            {
                Console.WriteLine($"{car1.Brand} is higher than {car2.Brand}.");
                car1points++;
            }
            else 
            {
                Console.WriteLine($"{car2.Brand} is higher than {car1.Brand}.");
                car2points++;
            }
            if (car1points > car2points)
            {
                Console.WriteLine($"{car1.Brand} is better than {car2.Brand}.");
            }
            else 
            {
                Console.WriteLine($"{car2.Brand} is better option than {car1.Brand}.");
            }
        }
       


    }
}
