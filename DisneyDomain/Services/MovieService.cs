using DisneyData.Models;
using DisneyData.Repositories;
using DisneyDomain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisneyDomain.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;

        public MovieService(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public void AddMovie(MovieDTO movieDTO)
        {
            try
            {
                Movie movie = new Movie()
                {
                    //Image = movieDTO.Image,
                    Title = movieDTO.Title,
                    CreationDate = movieDTO.CreationDate,
                    Score = movieDTO.Score,
                    GenreID = movieDTO.GenreID
                };
                _movieRepository.AddMovie(movie);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool DeleteMovie(int id)
        {
            if (id <= 0)
            {
                return false;
            }

            var movie = _movieRepository.GetById(id);
            if (movie == null)
            {
                throw new ApplicationException("Movie not found");
            }

            try
            {
                return _movieRepository.DeleteMovie(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Movie> DetailMovies()
        {
            return _movieRepository.GetMovies().ToList();
        }

        public List<Movie> OrderMoviesByCreationDate(string order)
        {
            if(order.Equals("DESC")) return _movieRepository.GetMovies().OrderByDescending(m => m.CreationDate).ToList();
            else return _movieRepository.GetMovies().OrderBy(m => m.CreationDate).ToList();
        }

        public Movie EditMovie(int id, MovieDTO updatedMovie)
        {
            var oldMovie = GetById(id);
            if (oldMovie != null)
            {
                oldMovie.Title = updatedMovie.Title;
                //oldMovie.Image = updateMovie.Image;
                oldMovie.CreationDate = updatedMovie.CreationDate;
                oldMovie.Score = updatedMovie.Score;
                oldMovie.GenreID = updatedMovie.GenreID;
                try
                {
                    return _movieRepository.EditMovie(oldMovie);
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
            return null;
        }

        public List<Movie> GetByGenre(int genreId)
        {
            return _movieRepository.GetMovies().Where(c => c.GenreID == genreId).ToList();
        }

        public Movie GetById(int id)
        {
            return _movieRepository.GetById(id);
        }

        public List<Movie> GetByTitle(string title)
        {
            return _movieRepository.GetMovies().Where(c => c.Title == title).ToList();
        }
    }
}
