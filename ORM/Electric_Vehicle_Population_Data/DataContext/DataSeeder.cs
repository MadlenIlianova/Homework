using Infrastructure;
using System;
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
            foreach (var vehicle in vehiclesFromCsv)
            {

                var state = _vehicleDbContext.States
                        .FirstOrDefault(s => s.StateName == vehicle.State)
                        ?? new State { StateName = vehicle.State, };

                var county = _vehicleDbContext.Counties
                        .FirstOrDefault(c => c.CountyName == vehicle.County)
                        ?? new County { CountyName = vehicle.County, State = state };

                var city = _vehicleDbContext.Cities
                        .FirstOrDefault(c => c.CityName == vehicle.City)
                       ?? new City { CityName = vehicle.City, County = county };

                var censusTract = _vehicleDbContext.CensusTracts
                        .FirstOrDefault(c => c.CensusTract2020 == vehicle.num2020CensusTract)
                        ?? new CensusTract { CensusTract2020 = vehicle.num2020CensusTract, City = city };

                var electricity = _vehicleDbContext.Electricities
                    .FirstOrDefault(e => e.ElectricVehicleType == vehicle.ElectricVehicleType &&
                    e.ElectricUtility == vehicle.ElectricUtility &&
                    e.ElectricRange == vehicle.ElectricRange &&
                    e.CAFV == vehicle.CleanAlternativeFuelVehicleCAFVEligibility)
                    //e.LegislativeDistrict == vehicle.LegislativeDistrict)

                    ?? new Electricity
                    {
                        ElectricVehicleType = vehicle.ElectricVehicleType,
                        ElectricUtility = vehicle.ElectricUtility,
                        ElectricRange = vehicle.ElectricRange,
                        CAFV = vehicle.CleanAlternativeFuelVehicleCAFVEligibility
                    };

                if (state.Id == 0) _vehicleDbContext.States.Add(state);
                if (county.Id == 0) _vehicleDbContext.Counties.Add(county);
                if (city.Id == 0) _vehicleDbContext.Cities.Add(city);
                if (censusTract.Id == 0) _vehicleDbContext.CensusTracts.Add(censusTract);
                if (electricity.Id == 0) _vehicleDbContext.Electricities.Add(electricity);

                _vehicleDbContext.SaveChanges();

                var vehicle1 = new Vehicle
                {
                    VIN = vehicle.VIN1_10,
                    Make = vehicle.Make,
                    Model = vehicle.VehicleModel,
                    ModelYear = vehicle.ModelYear,
                    BaseMSRP = vehicle.BaseMSRP,
                    DOLVehicleId = vehicle.DOLVehicleID,
                    Location = vehicle.VehicleLocation,
                    PostalCode = vehicle.PostalCode,
                    State = state,
                    Electricity = electricity,
                    City = city,
                    CityId = city.Id,
                    County = county,
                    CountyId = county.Id,
                    CensusTract = censusTract,
                    CensusTractId = censusTract.Id
                };
                _vehicleDbContext.Add(vehicle1);
            }
            _vehicleDbContext.SaveChanges();
        }
    }
}
