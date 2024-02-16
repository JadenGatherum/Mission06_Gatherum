using Mission06_Gatherum.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Mission06_Gatherum.Controllers
{
    public class HomeController : Controller
    {
        private JoelContext _context;
        public HomeController(JoelContext temp) //Constructor
        {
            _context = temp;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult MovieRecord()
        {
            return View();
        }

        [HttpPost]
        public IActionResult MovieRecord(Movie response)
        {
            response.Lent = "";
            response.Notes = "";
            _context.Movies.Add(response);
            _context.SaveChanges();

            return View("Confirmation", response);
        }

        public IActionResult GetToKnowJoel()
        {
            return View();
        }

    }
}
