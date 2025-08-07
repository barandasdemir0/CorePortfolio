using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CorePortfolio.Areas.Writer.Controllers
{
  
    [Authorize]
    [Area("Writer")]
    [Route("Writer/[controller]/[action]")]
    public class DefaultController : Controller
    {
        AnnouncementManager announcementManager = new AnnouncementManager(new EfAnnouncementDal());

        public IActionResult Index()
        {
            var values = announcementManager.TGetList();
            return View(values);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var values = announcementManager.TGetByID(id);
            return View(values);
        }

    
    }
}
