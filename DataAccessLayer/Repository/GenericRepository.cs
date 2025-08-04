using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
    public class GenericRepository<T> : IGenericDal<T> where T : class //diyoruzki generic repository bir t nesnesi alacak bu t nesneleri ı generic daldan gelecek ve bu t nesnesi classdan gelecek
    {
        public void Delete(T t)
        {
            //Context context = new Context(); bu işlemi kullanmıyoruz çünkü bu manuel yönetme yani kaynakları boşa kullanıyor
            using var c = new Context(); // bu yöntem ile işlem bittiğinde dispose yani kaynakları kapatır ve gereksiz sistem harcaması olmaz
            c.Remove(t);
            c.SaveChanges();
        }

        public T GetByID(int id)
        {
            using var c = new Context();
            return c.Set<T>().Find(id)!; // bunu koyarak null değil eminim ama null değilse çöker
        }

        public List<T> GetList()
        {
            using var c = new Context();
            return c.Set<T>().ToList(); // gelen t tablolarımız set ediyoruz sonra listeliyoruz
        }

        public void Insert(T t)
        {
            using var c = new Context();// yaptığı işlem kısaca contexte bağlan yani tablolara bu tabloları c üzerine ata
            c.Add(t);  //ekleme yapıyorsak veya silme veya güncelleme yap add remove update ile
            c.SaveChanges(); // ve bunu veritabanına kaydet
        }

        public void Update(T t)
        {
            using var c = new Context();
            c.Update(t);
            c.SaveChanges();
        }
    }
}
