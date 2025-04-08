using CarManager.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarManager.Data
{
    public class DbSeeder
    {
        public static void CarSeeder(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cars>().HasData
                (
                    new Cars
                    {
                        Id = 1,
                        Brand = "BMW",
                        ModelId = 1,
                        EngineId = 1,
                        Seats = 5,
                        Height = 1.5,
                        Width = 1.1,
                        Lenght = 5
                    },
                    new Cars

                    {
                        Id = 2,
                        Brand = "Audi",
                        ModelId = 2,
                        EngineId = 2,
                        Seats = 4,
                        Height = 1.7,
                        Width = 1.2,
                        Lenght = 6

                    }
                  );

            
                    
             
            modelBuilder.Entity<Engine>().HasData
                (

                new Engine
                {
                    Id = 1,
                    Horsepower = 600,
                    Cylinders = 6,
                    FuelType = "diesel" 
                },
                new Engine 
                {
                    Id = 2,
                    Horsepower = 300,
                    Cylinders = 8,
                    FuelType = "diesel"
                }
                );
            modelBuilder.Entity<Model>().HasData
                (new Model
                {
                    Id = 1,
                    Name = "M5",
                    Year = 2020
                },
                new Model 
                {
                    Id = 2,
                    Name = "Q7",
                    Year = 2018
                }
                );

        }


    }
}
