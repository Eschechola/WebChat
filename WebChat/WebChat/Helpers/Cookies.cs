using System;
using WebChat.Infra.Entities;
using System.Collections.Generic;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace WebChat.Helpers
{
    public class Cookies
    {
        private readonly HttpContext _httpContext;

        public Cookies(HttpContext httpContext)
        {
            _httpContext = httpContext;
        }

        public async void Login(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, "User")
            };

            var identidadeDeUsuario = new ClaimsIdentity(claims, "Basic");
            ClaimsPrincipal claimPrincipal = new ClaimsPrincipal(identidadeDeUsuario);

            var propriedadesDeAutenticacao = new AuthenticationProperties
            {
                AllowRefresh = true,
                ExpiresUtc = DateTime.Now.ToLocalTime().AddDays(2),
                IsPersistent = true
            };

            await _httpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimPrincipal, propriedadesDeAutenticacao);
        }


        public async void Logout()
        {
            await _httpContext.SignOutAsync();
        }
    }
}
