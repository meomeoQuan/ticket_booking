using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace ticket_booking.Models
{

    public class Seat
    {
        [Key]
        public int SeatId { get; set; }

        [Required]
        [StringLength(10)]
        public string SeatNumber { get; set; }

        [Required]
        [StringLength(50)]
        [RegularExpression("Available|Booked|Pending", ErrorMessage = "Invalid Seat Status")]
        public string SeatStatus { get; set; } = "Available";
        [Required]
        public int RoomId { get; set; }
        [ForeignKey("RoomId")]
        [ValidateNever]
        public Room Room { get; set; }
    }
}
