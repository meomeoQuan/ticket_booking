using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace ticket_booking.Models
{
    public class ShowTime
    {
        [Key]
        public int ShowTimeId { get; set; }

        public string ShowTimeStart { get; set; }
        public int MovieId { get; set; }
        [ForeignKey("MovieId")]
        [ValidateNever]
        public Movie Movie { get; set; }

        public int RoomId { get; set; }
        [ForeignKey("RoomId")]
        [ValidateNever]
        public Room Room { get; set; }
    }
}
