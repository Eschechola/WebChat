using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebChat.DTO;
using WebChat.Models;

namespace WebChat.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        [Route("/")]
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("/")]
        [ValidateAntiForgeryToken]
        public IActionResult Index(LoginDTO login)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View();

                //gera um hash para o usuário logado
                login.Hash = "#" + Guid.NewGuid()
                    .ToString()
                    .Substring(0, 4)
                    .ToUpper();

                return Redirect("/chat");
            }
            catch (Exception)
            {
                return Redirect("/");
            }
        }

        [HttpGet]
        [Authorize]
        [Route("/chat")]
        public IActionResult Chat()
        {
            return View();
        }
    }
}
