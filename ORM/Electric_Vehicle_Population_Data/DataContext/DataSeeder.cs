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
            _csvFileReader = csvFile;
            _vehicleDbContext = context;
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

            var states = new Dictionary<string, State>();
            var counties = new Dictionary<string, County>();
            var cities = new Dictionary<string, City>();
            var electricities = new Dictionary<string, Electricity>();
            var censusTracts = new Dictionary<(string, long?), CensusTract>();
            var vehicles = new Dictionary<int, Vehicle>();

            foreach (var row in vehiclesFromCsv)
            {
                if (!states.TryGetValue(row.State, out var state))
                {
                    state = new State { StateName = row.State };
                    states[row.State] = state;
                }

                if (!counties.TryGetValue(row.County, out var county))
                {
                    county = new County { CountyName = row.County, State = state };
                    counties[row.County] = county;
                }

                if (!cities.TryGetValue(row.City, out var city))
                {
                    city = new City { CityName = row.City, County = county };
                    cities[row.City] = city;
                }

                var censusKey = (row.City, row.num2020CensusTract);
                if (!censusTracts.TryGetValue(censusKey, out var censusTract))
                {
                    censusTract = new CensusTract { CensusTract2020 = row.num2020CensusTract, City = city };
                    censusTracts[censusKey] = censusTract;
                }

                if (!electricities.TryGetValue(row.ElectricVehicleType, out var electricity))
                {
                    electricity = new Electricity
                    {
                        ElectricVehicleType = row.ElectricVehicleType,
                        ElectricUtility = row.ElectricUtility,
                        ElectricRange = row.ElectricRange,
                        CAFV = row.CleanAlternativeFuelVehicleCAFVEligibility,
                        LegislativeDistrict = row.LegislativeDistrict
                    };
                    electricities[row.ElectricVehicleType] = electricity;
                }

                if (!vehicles.ContainsKey(row.DOLVehicleID))
                {
                    var vehicle = new Vehicle
                    {
                        VIN = row.VIN1_10,
                        Make = row.Make,
                        Model = row.VehicleModel,
                        ModelYear = row.ModelYear,
                        BaseMSRP = row.BaseMSRP,
                        DOLVehicleId = row.DOLVehicleID,
                        Location = row.VehicleLocation,
                        PostalCode = row.PostalCode,

                        State = state,
                        County = county,
                        City = city,
                        CensusTract = censusTract,
                        Electricity = electricity
                    };

                    vehicles[row.DOLVehicleID] = vehicle;
                }
            }
            _vehicleDbContext.Vehicles.AddRange(vehicles.Values);
            _vehicleDbContext.SaveChanges(); 
        }
    }
}

