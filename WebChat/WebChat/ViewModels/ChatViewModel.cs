using System.Collections.Generic;
using WebChat.Infra.Entities;

namespace WebChat.ViewModels
{
    public class ChatViewModel
    {
        public IList<User> Users { get; set; }
    }
}
