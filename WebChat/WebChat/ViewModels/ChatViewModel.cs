using System.Collections.Generic;
using WebChat.Domain.Entities;

namespace WebChat.Application.ViewModels
{
    public class ChatViewModel
    {
        public IList<User> Users { get; set; }
    }
}
