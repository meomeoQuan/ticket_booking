using System.ComponentModel.DataAnnotations;

namespace ticket_booking.Models
{
    public class Room
    {
        [Key]
        public int RoomId { get; set; }
        public int RoomCapacity { get; set; }
        public int RoomStatus { get; set; }
    }
}
