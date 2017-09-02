using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using Vidley.Models;
 
 
using Vidley.ViewModels;

namespace Vidley.Controllers.Api
{
    public class MoviesController : ApiController
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();

        }


        // Get /api/movies/
        public IEnumerable<Movie> GetMovies()
        {
            var movies = _context.Movies.ToList();
            return movies;

        }

        // Get /api/Movies/1  
        public Movie GetMovie(int Id)
        {

            var movie = _context.Movies.SingleOrDefault(m => m.Id == Id);
            if (movie == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return movie;
        }

        // Post /api/Movies/
        [HttpPost]
        public Movie CreateMovies(Movie movie)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            _context.Movies.Add(movie);
            _context.SaveChanges();
            return movie;
        }

        // put /api/Movies/1
        [HttpPut]
        public Movie UpdateMovie(int Id, Movie movie)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            var movieInDb = _context.Movies.SingleOrDefault(m => m.Id == Id);
            if (movieInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            movieInDb.Name = movie.Name;
            movieInDb.DateAdded = movie.DateAdded;
            movieInDb.ReleaseDate = movie.ReleaseDate;
            movieInDb.GenreId = movie.GenreId;
            movieInDb.NumberInStock = movie.NumberInStock;
            _context.SaveChanges();
            return movieInDb;
        }
        // Delete /api/movies/1
        [HttpDelete]
        public void DeleteMovie(int Id)
        {
            var movieInDb = _context.Movies.SingleOrDefault(m => m.Id == Id);
            if (movieInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            _context.Movies.Remove(movieInDb);
            _context.SaveChanges();


        }
    }
}
