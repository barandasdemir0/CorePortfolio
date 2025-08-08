using Microsoft.AspNetCore.Mvc;

namespace CorePortfolio.Controllers
{
    public class ErrorPageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
