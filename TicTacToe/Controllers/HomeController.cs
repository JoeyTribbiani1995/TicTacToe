using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TicTacToe.Controllers
{
    public class HomeController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            var culture = Request.HttpContext.Session.GetString("culture");
            ViewBag.Language = culture;
            return View();
        }

        public IActionResult SetCulture(string culture)
        {
            Request.HttpContext.Session.SetString("culture", culture);
            return RedirectToAction("Index");
        }
    }
}
