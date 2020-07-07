using System.Collections.Generic;
using WebChat.Domain.Entities;
using WebChat.Infra.Interfaces;
using WebChat.Services.Interfaces;

namespace WebChat.Services.Services
{
    public class MessageService : IMessageService
    {
        private readonly IMessageRepository _messageRepository;

        public MessageService(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;
        }

        public IList<Message> GetConversation(int receiverId, int senderId)
        {
            return _messageRepository.GetConversation(receiverId, senderId);
        }
    }
}
