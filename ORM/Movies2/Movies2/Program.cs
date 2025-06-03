using CsvHelper;
using MovieInfrastructure;
using MovieInfrastructure.Data;
using MovieInfrastructure.Repositories;
using MovieInfrastructure.Seed;
using System.Data;

namespace Movies2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using var context = new ApplicationDbContext() ;
                //CsvFileReader csv = new CsvFileReader();
                //csv.GetData();
                //var dataSeed = new DataSeeder(context, csv);
                //dataSeed.SeedDatabase();

            MovieRepository movieRepository = new MovieRepository(context);
            var list = movieRepository.GetMoviesContainingDog("Dog");
            foreach (var movie in list) 
            {
                Console.WriteLine(movie.Name);
            }
        }
    }
}
