using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CorePortfolio.Controllers
{
    [Authorize(Roles = "Admin")]
    public class SkillController : Controller
    {

        SkillManager skillManager = new SkillManager(new EfSkillDal());
        public IActionResult Index()
        {
            var values = skillManager.TGetList();
            return View(values);
        }

        [HttpGet]
        public IActionResult SkillInsert()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SkillInsert(Skill skill) 
        {
            skillManager.TAdd(skill);
            return RedirectToAction("Index");
        }

        public IActionResult SkillDelete(int id)
        {
            var detectedValues = skillManager.TGetByID(id);
            skillManager.TDelete(detectedValues);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult SkillUpdate(int id)
        {
            var detectedValues = skillManager.TGetByID(id);
            return View(detectedValues);
        }

        [HttpPost]
        public IActionResult SkillUpdate(Skill skill)
        {
            skillManager.TUpdate(skill);
            return RedirectToAction("Index");
        }


    }
}
