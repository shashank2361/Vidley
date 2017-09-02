using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using AutoMapper;
using Vidley.Dtos;
using Vidley.Models;
using AutoMapper;
 
 
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

        // here added delegates who do the mapping

        // Get /api/movies/
        public IEnumerable<MovieDto> GetMovies()
        {
            var movies = _context.Movies.ToList().Select(Mapper.Map<Movie, MovieDto>);
            return movies;

        }

        // Get /api/Movies/1  
        public MovieDto GetMovie(int Id)
        {

            var movie = _context.Movies.SingleOrDefault(m => m.Id == Id);
            if (movie == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return Mapper.Map<Movie , MovieDto>(movie);
        }

        // Post /api/Movies/
        [HttpPost]
        public MovieDto CreateMovies(MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            var movie = Mapper.Map<MovieDto, Movie>(movieDto);
            _context.Movies.Add(movie);
            _context.SaveChanges();
            movieDto.Id = movie.Id;
            return movieDto;
        }

        // put /api/Movies/1  -- this could be made void too
        [HttpPut]
        public MovieDto UpdateMovie(int Id, MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            var movieInDb = _context.Movies.SingleOrDefault(m => m.Id == Id);
            if (movieInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            //Mapper.Map<MovieDto, Movie>(movieDto, movieInDb);
            //                          sourceobj , traget object
            // the upper can be 
            Mapper.Map(movieDto, movieInDb);
            _context.SaveChanges();
            return movieDto;
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
