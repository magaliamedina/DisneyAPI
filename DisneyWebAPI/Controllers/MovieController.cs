using DisneyData.Models;
using DisneyDomain.DTO;
using DisneyDomain.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DisneyWebAPI.Controllers
{
    [Route("movies")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        //// GET: movies
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<Movie>>> ListMovies()
        //{
        //    var movies = _movieService.DetailMovies();
        //    if (movies == null)
        //    {
        //        return NotFound();
        //    }
        //    return movies;
        //}

        // GET: movies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Movie>>> DetailsMovies()
        {
            var movies = _movieService.DetailMovies();
            if (movies == null)
            {
                return NotFound();
            }
            return movies;
        }

        // GET: movies/notebook
        [HttpGet("{title}")]
        public async Task<ActionResult<IEnumerable<Movie>>> GetByTitle(string title)
        {
            var movies = _movieService.GetByTitle(title);
            if (movies == null)
            {
                return NotFound();
            }
            return movies;
        }

        // GET: movies/genderId/2
        [HttpGet("{genreId:int}")]
        public async Task<ActionResult<IEnumerable<Movie>>> GetByGenre(int genreId)
        {
            var movies = _movieService.GetByGenre(genreId);
            if (movies == null)
            {
                return NotFound();
            }
            return movies;
        }

        // GET: movies/order/ASC
        [HttpGet("order/{order}")]
        public async Task<ActionResult<IEnumerable<Movie>>> GetMoviesByCreationDate(string order)
        {
            var movies = _movieService.OrderMoviesByCreationDate(order);
            if (movies == null)
            {
                return NotFound();
            }
            return movies;
        }

        // PUT: movies/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMovie(int id, MovieDTO movie)
        {
            try
            {
                _movieService.EditMovie(id, movie);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw ex;

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return NoContent();
        }

        // POST: movies
        [HttpPost]
        public async Task<ActionResult<Movie>> PostMovie(MovieDTO  movie)
        {
            var movies = _movieService.DetailMovies();
            if (movies == null)
            {
                return Problem("Entity set 'DisneyDbContext.Movies'  is null.");
            }
            try
            {
                _movieService.AddMovie(movie);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            //return Ok(movie);
            return CreatedAtAction("DetailsMovies", new { id = movie.ID }, movie);
        }

        // DELETE: movies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            var movies = _movieService.DetailMovies();
            if (movies == null)
            {
                return NotFound();
            }
            try
            {
                var deleteFlag = _movieService.DeleteMovie(id);
                if (!deleteFlag)
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return NoContent();
        }
    }
}
