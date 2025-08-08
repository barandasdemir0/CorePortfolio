using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CorePortfolio.Controllers
{
    [Authorize(Roles = "Admin")]
    public class TestimonialController : Controller
    {
        TestimonialManager testimonialManager = new TestimonialManager(new EfTestimonialDal());
        public IActionResult Index()
        {
            var values = testimonialManager.TGetList();
            return View(values);
        }

        public IActionResult TestimonialDelete(int id)
        {
            var value = testimonialManager.TGetByID(id);
            testimonialManager.TDelete(value);
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult TestimonialInsert()
        {
            return View();
        }

        [HttpPost]
        public IActionResult TestimonialInsert(Testimonial testimonial)
        {
            testimonialManager.TAdd(testimonial);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult TestimonialUpdate(int id)
        {
            var value = testimonialManager.TGetByID(id);
            return View(value);
        }

        [HttpPost]
        public IActionResult TestimonialUpdate(Testimonial testimonial)
        {
            testimonialManager.TUpdate(testimonial);
            return RedirectToAction("Index");
        }
    }
}
