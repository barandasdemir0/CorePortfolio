using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CorePortfolio.Areas.Writer.Controllers
{
    [Area("Writer")]
    [Route("Writer/[controller]/[action]")]
    public class DashboardController : Controller
    {
        private readonly UserManager<WriterUser> _userManager;

        public DashboardController(UserManager<WriterUser> userManager)
        {
            _userManager = userManager;
        }

        Context context = new Context();
        public async Task<IActionResult> Index()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.name = values.NameSurname;

            //weather api
            string api = "c6a6e98c9ad84c8c6bb2af3312d3a87c";
            string connection = "https://api.openweathermap.org/data/2.5/weather?q=ankara&mode=xml&lang=tr&units=metric&appid=" + api;
            XDocument document = XDocument.Load(connection);
            ViewBag.weather = document.Descendants("temperature").ElementAt(0).Attribute("value").Value;

            ViewBag.v1 = context.WriterMessages.Where(x=>x.MessageReceiver == values.Email).Count();
            ViewBag.v2 = context.Announcements.Count();
            ViewBag.v3 = context.Users.Count();
            ViewBag.v4 = context.Skills.Count();


            return View();
        }
    }
}
