namespace ticket_booking.Models
{
    public class ChatMessage
    {
        public int ChatMessageId { get; set; }
        public int ChatId { get; set; }
        public int UserId { get; set; }
        public string ChatMessageContent { get; set; } = string.Empty;
        public DateTime ChatMessageTime { get; set; }
    }
}
