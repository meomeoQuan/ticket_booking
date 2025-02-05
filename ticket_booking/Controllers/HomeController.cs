using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ticket_booking.Data;
using ticket_booking.Models;
using ticket_booking.Models.ViewModel;
using System.Security.Claims;
using ticket_booking.Repositories.ChatRepository;
namespace ticket_booking.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly ApplicationDbContext _db;

        private readonly IMessageRepository _messageRepository;
        public HomeController(ILogger<HomeController> logger, ApplicationDbContext db, IMessageRepository messageRepository)
        {
            _logger = logger;
            _db = db;
            _messageRepository = messageRepository;
        }

        public IActionResult Index()
        {
            List<Movie> movieList = _db.Movies.ToList();
            return View(movieList);
        }
        public IActionResult Details(int Id)
        {
            ShowTimeVM showTimeVM = new ShowTimeVM()
            {
                TimeList = _db.ShowTimes.Include(a => a.Movie).Include(a => a.Room).Where(a => a.MovieId == Id).ToList(),
                Movie = _db.Movies.FirstOrDefault(a => a.MovieId == Id) ?? new Movie()
            };
            return View(showTimeVM);
        }
        //public IActionResult SeatMap(int RoomId)
        //{
        //    ShowTimeVM showTimeVM = new ShowTimeVM()
        //    {
        //        SeatList = _db.ShowTimes.Include(a => a.Movie).Include(a => a.Room).Where(a => a.MovieId == Id).ToList(),
        //        Movie = _db.Movies.FirstOrDefault(a => a.MovieId == Id)
        //    };
        //    return View(showTimeVM);
        //}

        //public IActionResult CreateChat(int recipientId)
        //{
        //    // Kiểm tra xem đoạn chat đã tồn tại chưa
        //    var existingChat = _db.Chats.FirstOrDefault(c =>
        //        c.ChatUsers != null &&
        //        c.ChatUsers.Any(m => m.UserId == User.Identity.Name) &&
        //        c.ChatUsers.Any(m => m.UserId == recipientId));

        //    if (existingChat != null)
        //    {
        //        return RedirectToAction("Index", "Chat", new { recipientId });
        //    }

        //    // Code to create a new chat if it doesn't exist
        //    // ...

        //    return RedirectToAction("Index", "Chat", new { recipientId });
        //}

        public IActionResult Book(int ShowTimeId)
        {
            ShowTime? showTime = _db.ShowTimes.Include(a => a.Movie).Include(a => a.Room).FirstOrDefault(a => a.ShowTimeId == ShowTimeId);
            if (showTime == null)
            {
                return NotFound();
            }
            return View(showTime);
        }

        public async Task<IActionResult> Chatdemo(int chatId)
        {
            var messages = await _messageRepository.GetMessagesByChatIdAsync(chatId);
            return View(messages);
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
