using System;
using Microsoft.AspNetCore.Mvc;
using WebChat.Application.ViewModels;
using WebChat.Services.Interfaces;

namespace WebChat.Application.Controllers.API
{
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IMessageService _messageService;

        public MessageController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        [HttpGet]
        [Route("/api/messages/{receiverId}/{senderId}")]
        public IActionResult Get(int receiverId, int senderId)
        {
            try
            {
                var messages = _messageService.GetConversation(receiverId, senderId);

                if (messages != null)
                {
                    return Ok(new ResultViewModel
                    {
                        Success = true,
                        Message = "Mensagens encontradas com sucesso!",
                        Data = new
                        {
                            Messages = messages 
                        }
                    });
                }

                return Ok(new ResultViewModel
                {
                    Success = false,
                    Message = "As mensagens não foram encontradas.",
                    Data = { }
                });
            }
            catch (Exception)
            {
                return BadRequest(new ResultViewModel
                {
                    Success = false,
                    Message = "Ocorreu algum erro interno, por favor tente novamente",
                    Data = { }
                });
            }
        }
    }
}
