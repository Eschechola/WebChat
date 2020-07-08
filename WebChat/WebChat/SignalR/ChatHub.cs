using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using WebChat.Domain.Entities;
using WebChat.Services.Interfaces;

namespace WebChat.Application.SignalR
{
    public class ChatHub : Hub
    {
        private readonly IMessageService _messageService;

        public ChatHub(IMessageService messageService)
        {
            _messageService = messageService;
        }

        public async Task SendMessage(User user, string message, int receiverID)
        {

            var messageSend = new Message
            {
                FkIdSender = user.Id,
                FkIdReceiver = receiverID,
                Text = message,
                SendDate = DateTime.Now
            };

            _messageService.Save(messageSend);

            await Clients.All.SendAsync("ReceiveMessage", messageSend);
        }
    }
}
