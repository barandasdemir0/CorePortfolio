using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CorePortfolio.ViewComponents.Dashboard
{
    public class TodoListPanel:ViewComponent
    {
        TodoListManager listManager = new TodoListManager(new EfTodoListDal());
        public IViewComponentResult Invoke()
        {
            var values = listManager.TGetList().Take(5).ToList();
            return View(values);
        }

    }
}
