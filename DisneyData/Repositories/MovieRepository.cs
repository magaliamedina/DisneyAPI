using DisneyData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisneyData.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private readonly DisneyDbContext _context;

        public MovieRepository(DisneyDbContext context)
        {
            _context = context;
        }

        public void AddMovie(Movie movie)
        {
            if (movie != null)
            {
                try
                {
                    _context.Movies.Add(movie);
                    _context.SaveChanges();
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
        }

        public bool DeleteMovie(int id)
        {
            var movie = _context.Movies.Find(id);
            if (movie != null)
            {
                try
                {
                    _context.Movies.Remove(movie);
                    _context.SaveChanges();
                }
                catch (Exception ex)
                {

                    throw ex;
                }
                return true;
            }
            return false;
        }

        

        public Movie EditMovie(Movie updatedMovie)
        {
            try
            {
                _context.Update(updatedMovie);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return updatedMovie;
        }

        public Movie GetById(int id)
        {
            return _context.Movies.Find(id);
        }

        public List<Movie> GetMovies()
        {
            return _context.Movies.ToList();
        }
    }
}
