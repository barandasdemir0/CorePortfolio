using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CorePortfolio.Controllers
{
    [AllowAnonymous]
    public class ErrorPageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Error404()
        {
            return View();
        }
    }
}
