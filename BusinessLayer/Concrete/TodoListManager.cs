using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class TodoListManager:ITodoListService
    {
        ITodoListDal _todoList;

        public TodoListManager(ITodoListDal todoList)
        {
            _todoList = todoList;
        }

        public void TAdd(ToDoList t)
        {
            _todoList.Insert(t);
        }

        public void TDelete(ToDoList t)
        {
            _todoList.Delete(t);
        }

        public ToDoList TGetByID(int id)
        {
            return _todoList.GetByID(id);
        }

        public List<ToDoList> TGetList()
        {
            return _todoList.GetList().Take(3).ToList();
        }

        public List<ToDoList> TGetListByFilter()
        {
            throw new NotImplementedException();
        }

        public void TUpdate(ToDoList t)
        {
            _todoList.Update(t);
        }
    }
}
