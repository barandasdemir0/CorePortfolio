using Microsoft.AspNetCore.Mvc;

namespace CorePortfolio.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
