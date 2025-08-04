using Microsoft.AspNetCore.Mvc;

namespace CorePortfolio.Controllers
{
    public class SkillController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
