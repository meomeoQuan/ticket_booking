using Microsoft.AspNetCore.Mvc.Rendering;

namespace ticket_booking.Models.ViewModel
{
    public class ShowTimeVM
    {
        public List<ShowTime> TimeList { get; set; }
        public List<SelectListItem> SeatList { get; set; }
        public Seat Seat { get; set; }
        public Movie Movie { get; set; }    
    }
}
