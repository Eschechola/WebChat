using System;

namespace WebChat.Domain.Entities
{
    public class Message : Base
    {
        public int FkIdSender { get; set; }
        public int FkIdReceiver { get; set; }
        public string Text { get; set; }
        public DateTime SendDate { get; set; }
    }
}
