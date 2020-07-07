using System.Collections.Generic;
using WebChat.Domain.Entities;

namespace WebChat.Services.Interfaces
{
    public interface IMessageService
    {
        IList<Message> GetConversation(int receiverId, int senderId);
    }
}
