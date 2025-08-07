using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IGenericDal <T> where T:class // sınıfımız olacak bu t değerler sınıf 
    {
        void Insert(T t); // t türünden nesneler türet
        void Delete(T t);
        void Update(T t);
        List<T> GetList(); // t türündeki nesneleri getir
        T GetByID(int id); // t türündeki nesneyi ıd olarak getir
        List<T> GetByFilter(Expression<Func<T, bool>> filter);
    }
}
