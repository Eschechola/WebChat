using System.Collections.Generic;
using WebChat.Domain.Entities;

namespace WebChat.Services.Interfaces
{
    public interface IMessageService
    {
        Message Save(Message message);
        IList<Message> GetConversation(int receiverId, int senderId);
    }
}
