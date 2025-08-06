using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CorePortfolio.Areas.Writer.Controllers
{
    public class DefaultController : Controller
    {

        [Area("Writer")]
        //[Authorize]
        public IActionResult Index()
        {
            return View();
        }
    }
}
