using System.Collections;
using System.Collections.Generic;
using WebChat.Domain.Entities;

namespace WebChat.Infra.Interfaces
{
    public interface IMessageRepository: IBaseRepository<Message>
    {
        IList<Message> GetConversation(int receiverId, int senderId);
    }
}
