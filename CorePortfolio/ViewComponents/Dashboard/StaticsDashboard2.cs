using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace CorePortfolio.ViewComponents.Dashboard
{
    public class StaticsDashboard2:ViewComponent
    {
        Context context = new Context();
        public IViewComponentResult Invoke()
        {
            ViewBag.portfolioCount = context.Portfolios.Count();
            ViewBag.serviceCount = context.Services.Count();
            ViewBag.messageCount = context.Messages.Count();
            return View();
        }
    }
}
