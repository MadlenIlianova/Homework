using Infrastructure;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using VehicleModels.Models;

namespace DataContext
{
    public class DataSeeder : IDataSeeder
    {
        private readonly VehicleDbContext _vehicleDbContext;
        private readonly CsvFileReader _csvFileReader;

        public DataSeeder(CsvFileReader csvFile, VehicleDbContext context)
        {
            this._csvFileReader = csvFile;
            this._vehicleDbContext = context;
        }

        public void SeedData()
        {
            if (_vehicleDbContext.Vehicles.Any())
            {
                Console.WriteLine("Има вече данни в таблицата Vehicles.");
                return;
            }

            var vehiclesFromCsv = _csvFileReader.GetData();
            Console.WriteLine($"{vehiclesFromCsv.Count}");

            Dictionary<string, State> states = new Dictionary<string, State>();
            Dictionary<string, County> counties = new Dictionary<string, County>();
            Dictionary<string, City> cities = new Dictionary<string, City>();
            Dictionary<string, Electricity> electricities = new Dictionary<string, Electricity>();
            Dictionary<string, Vehicle> vehicles = new Dictionary<string, Vehicle>();
            for (int i = 0; vehiclesFromCsv.Count > i; i++)
            {
                if (!states.ContainsKey(vehiclesFromCsv[i].State))
                {
                    State state = new State()
                    {
                        StateName = vehiclesFromCsv[i].State
                    };
                    states.Add(vehiclesFromCsv[i].State, state);
                    _vehicleDbContext.Add(state);
                }
                if (!counties.ContainsKey(vehiclesFromCsv[i].County))
                {
                    County county = new County()
                    {
                        CountyName = vehiclesFromCsv[i].County,
                        State = states[vehiclesFromCsv[i].State]
                    };
                    counties.Add(vehiclesFromCsv[i].County, county);
                    _vehicleDbContext.Add(county);
                }
                if (!cities.ContainsKey(vehiclesFromCsv[i].City))
                {
                    City city = new City()
                    {
                        CityName = vehiclesFromCsv[i].City,
                        County = counties[vehiclesFromCsv[i].County]
                    };
                    cities.Add(vehiclesFromCsv[i].City, city);
                    _vehicleDbContext.Add(city);
                }
                
                    CensusTract census = new CensusTract()
                    {
                        CensusTract2020 = vehiclesFromCsv[i].num2020CensusTract,
                        City = cities[vehiclesFromCsv[i].City]
                    };
                    
                    _vehicleDbContext.Add(census);

                
                if (!electricities.ContainsKey(vehiclesFromCsv[i].ElectricVehicleType))
                {
                    Electricity electricity = new Electricity()
                    {
                        ElectricVehicleType = vehiclesFromCsv[i].ElectricVehicleType,
                        ElectricUtility = vehiclesFromCsv[i].ElectricUtility,
                        ElectricRange = vehiclesFromCsv[i].ElectricRange,
                        CAFV = vehiclesFromCsv[i].CleanAlternativeFuelVehicleCAFVEligibility,
                        LegislativeDistrict = vehiclesFromCsv[i].LegislativeDistrict,
                    };
                    electricities.Add(vehiclesFromCsv[i].ElectricVehicleType, electricity);
                    _vehicleDbContext.Add(electricity);
                }
                if (!vehicles.ContainsKey(vehiclesFromCsv[i].VIN1_10))
                {
                    Vehicle vehicle = new Vehicle()
                    {
                        VIN = vehiclesFromCsv[i].VIN1_10,
                        Make = vehiclesFromCsv[i].Make,
                        Model = vehiclesFromCsv[i].VehicleModel,
                        ModelYear = vehiclesFromCsv[i].ModelYear,
                        BaseMSRP = vehiclesFromCsv[i].BaseMSRP,
                        DOLVehicleId = vehiclesFromCsv[i].DOLVehicleID,
                        Location = vehiclesFromCsv[i].VehicleLocation,
                        PostalCode = vehiclesFromCsv[i].PostalCode,
                        Electricity = electricities[vehiclesFromCsv[i].ElectricVehicleType],
                        State = states[vehiclesFromCsv[i].State],
                        City = cities[vehiclesFromCsv[i].City],
                        County = counties[vehiclesFromCsv[i].County],
                        CensusTract = census,

                    };
                    vehicles.Add(vehiclesFromCsv[i].VIN1_10, vehicle);
                    _vehicleDbContext.Add(vehicle);
                }
               
            }
            _vehicleDbContext.SaveChanges();
        }
    }
}
