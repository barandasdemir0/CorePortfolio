using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CorePortfolio.Controllers
{
    [Authorize(Roles = "Admin")]
    public class SocialMediaController : Controller
    {
        SocialMediaManager mediaManager = new SocialMediaManager(new EfSocialMediaDal());
        public IActionResult Index()
        {
            var values = mediaManager.TGetList();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddSocialMedia()
        {
           
            return View();
        }

        [HttpPost]
        public IActionResult AddSocialMedia(SocialMedia socialMedia)
        {
            socialMedia.SocialMediaStatus = true;
            mediaManager.TAdd(socialMedia);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult DeleteSocialMedia(int id)
        {
            var values = mediaManager.TGetByID(id);
            mediaManager.TDelete(values);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateSocialMedia(int id)
        {
           var values = mediaManager.TGetByID(id); 
            return View(values);
        }

        [HttpPost]
        public IActionResult UpdateSocialMedia(SocialMedia socialMedia)
        {
            socialMedia.SocialMediaStatus = true;
            mediaManager.TUpdate(socialMedia);
            return RedirectToAction("Index");
        }
    }
}
