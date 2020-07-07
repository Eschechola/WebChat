using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebChat.Application.ViewModels;
using WebChat.Services.Interfaces;

namespace WebChat.Application.Controllers.API
{
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [Authorize]
        [Route("/api/user/{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var user = _userService.Get(id);
                user.Password = "";
                user.Email = "";

                if(user != null)
                {
                    return Ok(new ResultViewModel
                    {
                        Success = true,
                        Message = "Usuário encontrado com sucesso",
                        Data = user
                    });
                }

                return Ok(new ResultViewModel
                {
                    Success = false,
                    Message = "O usuário não foi encontrado.",
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
