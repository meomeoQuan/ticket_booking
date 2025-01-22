using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ticket_booking.Data;
using ticket_booking.Models;
using ticket_booking.Models.ViewModel;

namespace ticket_booking.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly ApplicationDbContext _db;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext db)
        {
            _logger = logger;
            _db = db;
        }

        public IActionResult Index()
        {
          List<Movie> movieList = _db.Movies.ToList();
            return View(movieList);
        }
        public IActionResult Details(int id)
        {
            ShowTimeVM showTimeVM = new ShowTimeVM()
            {
                TimeList = _db.ShowTimes.Include(a => a.Movie).Include(a => a.Room).Where(a => a.MovieId == id).ToList(),
                Movie = _db.Movies.FirstOrDefault(a => a.MovieId == id)
            };
            return View(showTimeVM);
        }
        public IActionResult Book(int ShowTimeId)
        {
            ShowTime showTime = _db.ShowTimes.Include(a => a.Movie).Include(a => a.Room).FirstOrDefault(a => a.ShowTimeId == ShowTimeId);
            return View(showTime);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
