using Mission06_Gatherum.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;

namespace Mission06_Gatherum.Controllers
{
    // Controller responsible for handling movie-related operations
    public class HomeController : Controller
    {
        private JoelContext _context;

        // Constructor to initialize the controller with the database context
        public HomeController(JoelContext temp)
        {
            _context = temp;
        }

        // Action method for the home page
        public IActionResult Index()
        {
            return View();
        }

        // HTTP GET action method to display the movie record form
        [HttpGet]
        public IActionResult MovieRecord()
        {
            // Fetch categories and pass them to the view
            ViewBag.Categories = _context.Categories
                .OrderBy(x => x.category)
                .ToList();
            return View("MovieRecord", new Movie());
        }

        // HTTP POST action method to handle movie record submission
        [HttpPost]
        public IActionResult MovieRecord(Movie response)
        {
            if (ModelState.IsValid)
            {
                response.LentTo = "";
                response.Notes = "";
                _context.Movies.Add(response); // add a record to the database
                _context.SaveChanges();

                return View("Confirmation", response);
            }
            else
            {
                // If model state is not valid, reload the form with validation errors
                ViewBag.Categories = _context.Categories
                    .OrderBy(x => x.category)
                    .ToList();
                return View(response);
            }
        }

        // Action method to display information about Joel
        public IActionResult GetToKnowJoel()
        {
            return View();
        }

        // Action method to display all movies
        public IActionResult AllMovies()
        {
            var movies = _context.Movies
                .Include(x => x.Category)
                .ToList();

            return View(movies);
        }

        // HTTP GET action method to display the movie edit form
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var recordtoEdit = _context.Movies
                .Single(x => x.MovieId == id);
            ViewBag.Categories = _context.Categories
                .OrderBy(x => x.category)
                .ToList();
            return View("MovieRecord", recordtoEdit);
        }

        // HTTP POST action method to handle movie edit submission
        [HttpPost]
        public IActionResult Edit(Movie updatedInfo)
        {
            _context.Update(updatedInfo);
            _context.SaveChanges();
            return RedirectToAction("AllMovies");
        }

        // HTTP GET action method to display the movie delete confirmation page
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var recordtoDelete = _context.Movies
                .Single(x => x.MovieId == id);

            return View(recordtoDelete);
        }

        // HTTP POST action method to handle movie deletion
        [HttpPost]
        public IActionResult Delete(Movie updatedInfo)
        {
            _context.Movies.Remove(updatedInfo);
            _context.SaveChanges();
            return RedirectToAction("AllMovies");
        }
    }
}