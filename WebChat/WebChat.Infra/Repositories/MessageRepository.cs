using System.Collections.Generic;
using WebChat.Domain.Entities;
using WebChat.Infra.Data.Context;
using WebChat.Infra.Interfaces;
using System.Linq;

namespace WebChat.Infra.Repositories
{
    public class MessageRepository : BaseRepository<Message>, IMessageRepository
    {
        private readonly ChatDataContext _context;

        public MessageRepository(ChatDataContext context) : base(context)
        {
            _context = context;
        }

        public IList<Message> GetConversation(int receiverId, int senderId)
        {
            var messages = from msg in _context.Messages

                           where
                            (msg.FkIdReceiver == receiverId && msg.FkIdSender == senderId)

                            ||

                            (msg.FkIdReceiver == senderId && msg.FkIdSender == receiverId)

                           select msg;

            return messages.ToList();
        }
    }
}
