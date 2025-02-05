using Microsoft.AspNetCore.SignalR;
using Microsoft.IdentityModel.Tokens;
using ticket_booking.Data;
using ticket_booking.Models;

namespace ticket_booking.Hubs
{
    public class ChatHub : Hub
    {
        private readonly ApplicationDbContext _context;
        public ChatHub(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task SendMessage(int ChatId, int UserId, string Message)
        {
            var chat = await _context.Chats.FindAsync(ChatId);
            var user = await _context.Users.FindAsync(UserId);

            var newMessage = new ChatMessage
            {
                ChatId = chat.ChatId,
                UserId = user.UserId,
                ChatMessageContent = Message,
                ChatMessageTime = DateTime.Now
            };
            _context.ChatMessages.Add(newMessage);

            //if (string.IsNullOrEmpty(user.Name))
            //    await Clients.All.SendAsync("ReceiveMessage", UserId, Message);
            //else
            //    await Clients.Client(user.Name).SendAsync("ReceiveMessage", user, Message); 
            
            await _context.SaveChangesAsync();
            // Send message to all clients in the chat group
            await Clients.Group(chat.ChatId.ToString()).SendAsync("ReceiveMessage", user.Name, Message);
        }
    }
}
