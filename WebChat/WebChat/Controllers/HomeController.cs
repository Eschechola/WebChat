using System;
using WebChat.Application.DTO;
using WebChat.Application.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using WebChat.Application.ViewModels;
using WebChat.Domain.Entities;
using WebChat.Services.Interfaces;

namespace WebChat.Application.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserService _userService;

        public HomeController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [Route("/")]
        [AllowAnonymous]
        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
                return Redirect("/chat");

            return View();
        }

        [HttpPost]
        [Route("/")]
        [ValidateAntiForgeryToken]
        public IActionResult Index(UserViewModel loginUser)
        {
            try
            {
                if (User.Identity.IsAuthenticated)
                    return Redirect("/chat");

                var userExists = _userService.GetByEmail(loginUser.Email);

                if(loginUser.IsLogin == "1")
                {
                    //se não existir OU a senha for inválida
                    if(userExists == null || userExists.Password != loginUser.Password)
                    {
                        ViewBag.Error = "Email e/ou senha está(ão) inválido(s)";
                        
                        return View();
                    }

                    new Cookies(HttpContext).Login(userExists);
                }
                else
                {
                    if (!ModelState.IsValid)
                    {
                        ViewBag.Error = "Os dados informados estão inválidos.";

                        return View();
                    }


                    if(userExists != null)
                    {
                        ViewBag.Error = "O Email informado já existe na nossa base de dados!";

                        return View();
                    }

                    var user = new User
                    {
                        Email = loginUser.Email,
                        Name = loginUser.Name,
                        Password = loginUser.Password
                    };


                    //não gerar hash repetido pra usuário
                    do
                    {
                        user.Hash = "#" + Guid.NewGuid()
                                    .ToString()
                                    .Substring(0, 4)
                                    .ToUpper();

                    } while (_userService.GetByHash(user.Hash) != null);

                    var userCreated = _userService.Save(user);

                    new Cookies(HttpContext).Login(userCreated);
                }

                return Redirect("/chat");
            }
            catch (Exception)
            {
                ViewBag.Error = "Ocorreu algum erro ao tentar se comunicar com o servidor. Por favor tente novamente!";
                
                return View();
            }
        }

        [HttpGet]
        [Authorize]
        [Route("/chat")]
        public IActionResult Chat()
        {
            var chatViewModel = new ChatViewModel
            {
                Users = _userService.GetAll()
            };


            return View(chatViewModel);
        }


        [HttpGet]
        [Authorize]
        [Route("/logout")]
        public IActionResult Logout()
        {
            new Cookies(HttpContext).Logout();

            return Redirect("/");
        }
    }
}
