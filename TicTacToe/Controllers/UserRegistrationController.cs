using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TicTacToe.Services;
using TicTacToe.Models;
using System;

namespace TicTacToe.Controllers
{
    public class UserRegistrationController : Controller
    {
        private IUserService _userService;
        public UserRegistrationController(IUserService userService)
        {
            _userService = userService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(UserModel userModel)
        {
            if (ModelState.IsValid)
            {
                await _userService.RegisterUser(userModel);
                return RedirectToAction(nameof(EmailConfirmation), new { userModel.Email });
            }
            return View(userModel);
        }

        [HttpGet]
        public async Task<IActionResult> EmailConfirmation(string email)
        {
            var userTemp = await _userService.GetUserByEmail(email);
            if(userTemp?.IsEmailConfirmed == true)
            {
                return RedirectToAction("Index", "GameInvitation", new { email });
            }
           
             ViewBag.Email = email;

             userTemp.IsEmailConfirmed = true;
             userTemp.EmailConfirmationDate = DateTime.Now;
             await _userService.UpdateUser(userTemp);
 
            return View();
        }
    }
}
