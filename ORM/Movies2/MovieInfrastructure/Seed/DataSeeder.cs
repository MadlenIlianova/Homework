using CsvHelper;
using MovieInfrastructure.Data;
using Movies2.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieInfrastructure.Seed
{
    public class DataSeeder
    {
        private readonly ApplicationDbContext _context;
        private readonly ICsvFileReader _csvReader;

        public DataSeeder(ApplicationDbContext context, ICsvFileReader csvReader)
        {
            _context = context;
            _csvReader = csvReader;
        }

        public void SeedDatabase()
        {
            CsvFileReader csvFileReader = new CsvFileReader();
            var moviesList = csvFileReader.GetData();
            var movieList = new List<Movie>();
            
            foreach (var csvMovie in moviesList)
            {
                var director = _context.Directors
                    .FirstOrDefault(d => d.Name == csvMovie.Director)
                    ?? new Director { Name = csvMovie.Director };

                var cast = _context.Casts
                    .FirstOrDefault(c => c.Name == csvMovie.Cast)
                    ?? new Cast { Name = csvMovie.Cast };

                var genres = csvMovie.Genre
                    .Split(',')
                    .Select(g => g.Trim())
                    .Distinct()
                    .Select(name =>
                        _context.Genres.FirstOrDefault(gg => gg.Name == name)
                        ?? new Genre { Name = name })
                    .ToList();

                var movie = new Movie
                {
                    Name = csvMovie.MovieName,
                    Duration = csvMovie.Duration,
                    IMDBRating = csvMovie.IMDBRating,
                    Metascore = csvMovie.Metascore,
                    Vote = csvMovie.Votes,
                    Gross = csvMovie.Gross,
                    ReleaseYear = csvMovie.ReleaseYear,
                    Director = director,
                    Cast = cast,
                    Genres = genres
                };

                _context.Movies.Add(movie);
            }
            _context.SaveChanges();
        }
    }
}
