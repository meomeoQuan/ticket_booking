using Microsoft.AspNet.SignalR.Messaging;
using ticket_booking.Models;

namespace ticket_booking.Repositories.ChatRepository
{
    public interface IMessageRepository
    {
        Task<List<ChatMessage>> GetMessagesByChatIdAsync(int chatId);
    }
}
