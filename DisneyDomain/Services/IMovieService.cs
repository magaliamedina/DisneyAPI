using DisneyData.Models;
using DisneyDomain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisneyDomain.Services
{
    public  interface IMovieService
    {
        public List<Movie> OrderMoviesByCreationDate(string order);
        public List<Movie> DetailMovies();
        //public List<Movie> ListMovies(); //only image, title, creationDate
        public void AddMovie(MovieDTO movie);
        public Movie EditMovie(int id, MovieDTO updatedMovie);
        public bool DeleteMovie(int id);
        public Movie GetById(int id); //GetById
        public List<Movie> GetByTitle(string title);
        public List<Movie> GetByGenre(int genreID);
    }
}
