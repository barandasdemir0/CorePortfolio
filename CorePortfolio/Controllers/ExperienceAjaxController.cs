using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CorePortfolio.Controllers
{
    public class ExperienceAjaxController : Controller
    {

        ExperienceManager experienceManager = new ExperienceManager(new EfExperienceDal());
        public IActionResult Index()
        {

            return View();
        }


        public IActionResult GetExperienceList()
        {
            var values = JsonConvert.SerializeObject(experienceManager.TGetList());
            return Json(values);
        }

        [HttpPost]
        public IActionResult AddExperience(Experience experience)
        {
            experienceManager.TAdd(experience);
            var values = JsonConvert.SerializeObject(experience);
            return Json(values);

        }


        public IActionResult GetById(int ExprerienceID)
        {
            var v = experienceManager.TGetByID(ExprerienceID);
            var values = JsonConvert.SerializeObject(v);
            return Json(values);
        }
        public IActionResult DeleteExperience(int id)
        {
            var v = experienceManager.TGetByID(id);
            experienceManager.TDelete(v);
            return NoContent();
        }
        public IActionResult UpdateExperince(Experience p)
        {
            var v = experienceManager.TGetByID(p.ExperienceID);
            experienceManager.TUpdate(v);
            var values = JsonConvert.SerializeObject(p);
            return Json(values);
        }

    }
}
