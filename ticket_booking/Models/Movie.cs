using System.ComponentModel.DataAnnotations;

namespace ticket_booking.Models
{
    public class Movie
    {
        [Key]
        public int MovieId { get; set; }
        public string Title { get; set; }
        public string Discription { get; set; }
    }
}
