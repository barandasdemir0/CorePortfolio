using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CorePortfolio.Controllers
{
    [Authorize(Roles = "Admin")]
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
            PorfolioValidator validationRules = new PorfolioValidator();//tanımladığımız class klasörde
            ValidationResult validationResult = validationRules.Validate(portfolio);// validasyona bak portfoliodan gelen verilere validasyondan geçiyormu
            if (validationResult.IsValid) // eğer kurallar geçiyorsa
            {
                portfolio.Status = true;
                portfolioManager.TAdd(portfolio);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in validationResult.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);// modelden hatayı getir
                }
                
            }
            return View();

        }

        public IActionResult PortfolioDelete(int id)
        {
            var detectedValues = portfolioManager.TGetByID(id);
            portfolioManager.TDelete(detectedValues);
            return RedirectToAction("Index");
        }


        [HttpGet]
        public ActionResult PortfolioUpdate(int id)
        {
           var values =  portfolioManager.TGetByID(id);
            return View(values);
        }
        [HttpPost]
        public ActionResult PortfolioUpdate(Portfolio portfolio)
        {
            PorfolioValidator validationRules = new PorfolioValidator();//tanımladığımız class klasörde
            ValidationResult validationResult = validationRules.Validate(portfolio);// validasyona bak portfoliodan gelen verilere validasyondan geçiyormu
            if (validationResult.IsValid) // eğer kurallar geçiyorsa
            {
                portfolio.Status = true;
                portfolioManager.TUpdate(portfolio);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in validationResult.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);// modelden hatayı getir
                }

            }
            return View();

        }



    }
}
