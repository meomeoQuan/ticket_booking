using System.ComponentModel.DataAnnotations;

namespace ticket_booking.Models
{
    public class User
    {
        [Key]
        
        public int UserId { get; set; }
        public required string Name { get; set; }

    }
}
