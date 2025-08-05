using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace CorePortfolio.Controllers
{
    public class PortfolioController : Controller
    {

        PortfolioManager portfolioManager = new PortfolioManager(new EfPortfolioDal());
        public IActionResult Index()
        {
            var values = portfolioManager.TGetList();
            return View(values);
        }

        [HttpGet]
        public ActionResult PortfolioInsert()
        {
            return View();
        }
        [HttpPost]
        public ActionResult PortfolioInsert(Portfolio portfolio)
        {
            portfolio.Status = true;
            portfolioManager.TAdd(portfolio);
            return RedirectToAction("Index");
        }
    }
}
