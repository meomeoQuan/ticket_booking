namespace ticket_booking.Models
{
    public class Chat
    {
        public int ChatId { get; set; }
        public List<ChatMessage>? ChatMessages { get; set; }
        public List<ChatUser>? ChatUsers { get; set; }
        public DateTime ChatTime { get; set; }
    }
}
