using Microsoft.AspNetCore.Mvc;

namespace CorePortfolio.Areas.Writer.Controllers
{
    public class DefaultController : Controller
    {

        [Area("Writer")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
