using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Data.Entity.Validation;
using JetBrains.Reflection;
using Vidley.Models;
using Vidley.ViewModels;

namespace Vidley.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies
        private ApplicationDbContext _context;
        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        public ActionResult Index()
        {

            var movies = _context.Movies.Include(x => x.Genre).ToList();
            return View(movies);
        }

        public ActionResult Details(int id)
        {

            var movies   = _context.Movies.Include(x => x.Genre).SingleOrDefault(c => c.Id == id);
            
            return View(movies);
        }



        public ActionResult Random()
        {
            var movie = new Movie() { Name = "Shrek!" };
            //      ViewData["Movie"] = movie;
            //    ViewBag.Movie = movie;
            var customers = new List<Customer>
           {
               new Customer {Name = "Customer 1"},
               new Customer {Name = "Customer 1"}
           };

            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };

            return View(viewModel);

        }

        public ActionResult New()
        {
            var genres = _context.Genres.ToList();
            var viewModel = new MovieFormViewModel()
            {
           //     Movie = new Movie(),

                Genres = genres
            }
            ;
            return View("MovieForm", viewModel);
        }
        public ActionResult Edit(int id)
        {
           var movie = _context.Movies.SingleOrDefault(c => c.Id == id);
            if (movie == null)
            {
                return HttpNotFound();
            }

            var viewModel = new MovieFormViewModel(movie)
            {
                Genres = _context.Genres.ToList()

            };

            return View("MovieForm",viewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new MovieFormViewModel(movie)
                {
             //       Movie = new Movie(), 
                    Genres = _context.Genres.ToList()
                };
        //        return View("MovieForm", viewModel);
            }

            if (movie.Id == 0)
                {
                    _context.Movies.Add(movie);
                }
            else
            {
         
                using (var _context = new ApplicationDbContext())
                {
                    var movieInDb = _context.Movies.SingleOrDefault(c => c.Id == movie.Id);
                    movieInDb.Name = movie.Name;
                    movieInDb.DateAdded = movie.DateAdded;
                    movieInDb.ReleaseDate = movie.ReleaseDate;
                    if (movieInDb.GenreId > 0)
                    {
                        movieInDb.Genre = null;
                        movieInDb.GenreId = movie.GenreId;

                    }
                    
                    movieInDb.NumberInStock = movie.NumberInStock;

                    _context.Movies.Add(movie);
                //    _context.Movies.Attach(movie);
                }
                

            }
            try
            {
               _context.SaveChanges();
                Dispose(true);
            }
            catch (DbEntityValidationException e)
            {
                var errors = ModelState.SelectMany(x => x.Value.Errors.Select(z => z.Exception));
                Console.WriteLine(e);
            }

            return RedirectToAction("Index", "Movies");
        }
        // movies 
        
        //public ActionResult Index ( int? pageIndex, string sortBy)
        //{
        //    if (!pageIndex.HasValue)
        //    {
        //        pageIndex = 1;
        //    }
        //    if (string.IsNullOrWhiteSpace(sortBy))
        //    {
        //        sortBy = "Name";
        //    }

        //    return Content(String.Format("pageIndex={0}&sortBy={1}", pageIndex, sortBy));

        //}

        //[Route("movies/released/{year}/{month:regex(\\d{4}):range(1,12)}")]
        //public ActionResult ByReleaseDate(int year, int month)
        //{
        //    return Content(year + "/" + month);
        //}


        

    }
}


// return Content("hello world");
// return HttpNotFound();
// return new EmptyResult();
// return RedirectToAction("Index", "Home", new { page =1 ,sortBy = "Name"});



//var viewModel = new MovieFormViewModel()
//{
//    Id = movie.Id,
//    Name = movie.Name,
//    ReleaseDate=movie.ReleaseDate,
//    NumberInStock=movie.NumberInStock,



//    Movie = movie,
//    Genres = _context.Genres.ToList()

//};


//public ActionResult Save(Movie movie)
//{
//if (!ModelState.IsValid)
//{
//var viewModel = new MovieFormViewModel
//    {
//        Movie = new Movie(),
//        Genres = _context.Genres.ToList()
//    };
//    return View("MovieForm", viewModel);
//}