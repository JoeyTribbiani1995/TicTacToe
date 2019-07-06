using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TicTacToe.Services;
using TicTacToe.Models;
using Microsoft.AspNetCore.Http;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TicTacToe.Controllers
{
    public class GameInvitationController : Controller
    {
        private IUserService _userService;
        public GameInvitationController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> Index(string email)
        {
            var gameInvitationModel = new GameInvitationModel
            {
                InvitedBy = email
            };

            HttpContext.Session.SetString("email", email);
            return View(gameInvitationModel);
        }
    }
}
