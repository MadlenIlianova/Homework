using MovieInfrastructure.Data;
using Movies2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieInfrastructure.Repositories
{
    public class MovieRepository
    {
        private readonly ApplicationDbContext _context;

        public MovieRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Movie> GetMoviesContainingDog(string keyword) 
        {
        return _context.Movies
                .Where(m => m.Name.ToLower().Contains(keyword.ToLower()))
                .ToList();
        }
    }
}
