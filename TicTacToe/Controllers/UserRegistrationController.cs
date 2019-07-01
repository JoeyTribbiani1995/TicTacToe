using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TicTacToe.Services;
using TicTacToe.Models;

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
            await _userService.RegisterUser(userModel);
            return Content($"User {userModel.FirstName} {userModel.LastName} has been registered successfully");
        }
    }
}
