using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace CorePortfolio.Controllers
{
    public class ServiceController : Controller
    {
        ServiceManager serviceManager = new ServiceManager(new EfServiceDal());
        public IActionResult Index()
        {
            var values = serviceManager.TGetList();
            return View(values);
        }


        [HttpGet]
        public IActionResult ServiceInsert()
        {
            return View();
        }
        [HttpPost]
        public IActionResult ServiceInsert(Service service)
        {
            serviceManager.TAdd(service);
            return RedirectToAction("Index");
        }

        public IActionResult ServiceDelete(int id)
        {
            var detectedValues = serviceManager.TGetByID(id);
            serviceManager.TDelete(detectedValues);
            return RedirectToAction("Index");
        }



        [HttpGet]
        public IActionResult ServiceUpdate(int id)
        {
            var detectedValues = serviceManager.TGetByID(id);
            return View(detectedValues);
        }
        [HttpPost]
        public IActionResult ServiceUpdate(Service service)
        {
            serviceManager.TUpdate(service);
            return RedirectToAction("Index");
        }
    }
}
