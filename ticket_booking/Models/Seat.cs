using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace ticket_booking.Models
{
    public class Seat
    {
        [Key]
        public int SeatId { get; set; }

        public string Row { get; set; }
        public string Column { get; set; }

        public int SeatStatus { get; set; }

        public int RoomId { get; set; }
        [ForeignKey("RoomId")]
        [ValidateNever]
        public Room Room { get; set; }
    }
}
