using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace CorePortfolio.Controllers
{
    public class ExperienceController : Controller
    {
        ExperienceManager experienceManager = new ExperienceManager(new EfExperienceDal());
        public IActionResult Index()
        {
            var values = experienceManager.TGetList();
            return View(values);
        }

        [HttpGet]
        public IActionResult ExperienceInsert()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ExperienceInsert(Experience experience)
        {
            experienceManager.TAdd(experience);
            return RedirectToAction("Index");
        }

        public IActionResult ExperienceDelete(int id)
        {
            var detectedValues = experienceManager.TGetByID(id);
            experienceManager.TDelete(detectedValues);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult ExperienceUpdate(int id)
        {
            var detectedValues = experienceManager.TGetByID(id);
            return View(detectedValues);
        }

        [HttpPost]
        public IActionResult ExperienceUpdate(Experience experience)
        {
            experienceManager.TUpdate(experience);
            return RedirectToAction("Index");
        }


    }
}
