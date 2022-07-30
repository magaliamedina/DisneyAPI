using DisneyData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisneyData.Repositories
{
    public interface IMovieRepository
    {
        public List<Movie> GetMovies(); 
        public void AddMovie(Movie movie);
        public Movie EditMovie(Movie updatedMovie);
        public bool DeleteMovie(int id);
        public Movie GetById(int id); //GetById
    }
}
