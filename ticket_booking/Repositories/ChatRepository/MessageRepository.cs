using Microsoft.AspNet.SignalR.Messaging;
using ticket_booking.Data;
using Microsoft.EntityFrameworkCore;
using ticket_booking.Models;

namespace ticket_booking.Repositories.ChatRepository
{
    public class MessageRepository : IMessageRepository
    {
        private readonly ApplicationDbContext _context;

        public MessageRepository()
        {
        }

        public MessageRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<ChatMessage>> GetMessagesByChatIdAsync(int chatId)
        {
            return await _context.ChatMessages
                .Where(m => m.ChatId == chatId)
                .OrderBy(m => m.ChatMessageTime)
                .ToListAsync();
        }
    }
}
