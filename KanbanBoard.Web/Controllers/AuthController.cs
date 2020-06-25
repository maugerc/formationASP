using System.Collections.Generic;
using System.Security.Claims;
using KanbanBoard.Core.Services;
using KanbanBoard.Web.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

namespace KanbanBoard.Web.Controllers
{
    public class AuthController : Controller
    {
        private readonly KanbanBoardService _kanbanBoardService;

        public AuthController(KanbanBoardService kanbanBoardService)
        {
            _kanbanBoardService = kanbanBoardService;
        }

        public IActionResult Login()
        {
            return View(new LoginViewModel());
        }

        [HttpPost]
        public IActionResult Login([FromForm] LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = _kanbanBoardService.GetUser(model.UserName, model.Password);

                if (user != null)
                {

                    var claims = new List<Claim>()
                    {
                        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                        new Claim(ClaimTypes.Name, user.UserName)
                    };

                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

                    HttpContext.SignInAsync(claimsPrincipal);
                }
            }

            return View(model);
        }
    }
}
