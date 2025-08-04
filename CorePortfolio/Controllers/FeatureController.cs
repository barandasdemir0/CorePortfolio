using Microsoft.AspNetCore.Mvc;

namespace CorePortfolio.Controllers
{
    public class FeatureController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
