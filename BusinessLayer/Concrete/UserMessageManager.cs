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
    public class UserMessageManager : IUserMessageService
    {
        IUserMessageDal _messageDal;

        public UserMessageManager(IUserMessageDal messageDal)
        {
            _messageDal = messageDal;
        }

        public List<UserMessage> GetUserMessagesWithUserService()
        {
           return _messageDal.GetUserMessagesWithUser();
        }

        public void TAdd(UserMessage t)
        {
            _messageDal.Insert(t);
        }

        public void TDelete(UserMessage t)
        {
            _messageDal.Delete(t);
        }

        public UserMessage TGetByID(int id)
        {
            return _messageDal.GetByID(id);
        }

        public List<UserMessage> TGetList()
        {
            return _messageDal.GetList();
        }

        public void TUpdate(UserMessage t)
        {
            _messageDal.Update(t);
        }
    }
}
