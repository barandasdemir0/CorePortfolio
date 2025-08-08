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
    public class WriterUserManager : IWriterService
    {
        IWriteDal _writeDal;

        public WriterUserManager(IWriteDal writeDal)
        {
            _writeDal = writeDal;
        }

        public void TAdd(WriterUser t)
        {
            _writeDal.Insert(t);
        }

        public void TDelete(WriterUser t)
        {
            _writeDal.Delete(t);
        }

        public WriterUser TGetByID(int id)
        {
           return _writeDal.GetByID(id);
        }

        public List<WriterUser> TGetList()
        {
           return _writeDal.GetList();
        }

        public List<WriterUser> TGetListByFilter()
        {
            throw new NotImplementedException();
        }

        public void TUpdate(WriterUser t)
        {
            _writeDal.Update(t);
        }
    }
}
