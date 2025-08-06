using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace CorePortfolio.ViewComponents.Dashboard
{
    public class FeatureStatistics:ViewComponent
    {
        Context context = new Context();
        public IViewComponentResult Invoke()
        {
            ViewBag.HowMuchSkill = context.Skills.Count();
            ViewBag.totalMessageNotRead = context.Messages.Where(x=>x.Status == false).Count();
            ViewBag.totalMessageRead = context.Messages.Where(x=>x.Status == true).Count();
            ViewBag.experienceCount = context.Experiences.Count();
            return View();
        }
    }
}
