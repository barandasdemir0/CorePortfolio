using Core_Proje_Api.DAL.ApiContext;
using Core_Proje_Api.DAL.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        Context context = new Context();
        [HttpGet] //listeleme
        public IActionResult GetCategoryList()
        {
           
            return Ok(context.Categories.ToList());
        }

        [HttpGet("{id}")] //ıdye göre listeleme
        public IActionResult GetCategoryListId(int id)
        {
            var values = context.Categories.Find(id);
            if (values==null)
            {
                return NotFound();
            }
            else
            {
                return Ok(values);

            }

               
        }


        [HttpPost] //ekleme
        public IActionResult CategoryAdd(Category category)
        {

            context.Add(category);
            context.SaveChanges();
            return Created("", category);
        }

        [HttpDelete] //silme
        public IActionResult CategoryDelete(int id)
        {
            var values = context.Categories.Find(id);
            if (values==null)
            {
                return NotFound();
            }
            else
            {
                context.Remove(values);


                context.SaveChanges();
                return NoContent();
            }


              
        }

        [HttpPut]//güncelleme
        public IActionResult CategoryUpdate(Category category)
        {
            var values = context.Find<Category>(category.CategoryID);
            if (values== null)
            {
                return NotFound();
            }
            else
            {
                values.CategoryName = category.CategoryName;
                context.Update(values);
                context.SaveChanges();
                return NoContent();
            }
        }






    }
}
