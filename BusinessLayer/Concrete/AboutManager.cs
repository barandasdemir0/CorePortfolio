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
    public class AboutManager : IAboutService //ıabout service ile ı generic servicedeki sınıflara erişiyoruz tadd tupdate felan
    {
        IAboutDal _aboutDal; //aboutdal ile dal sınındaki abouta erişiyoruz oradanda ıgenerice erişiyoruz böylece silme güncelleme kaydetme işlemi yapacaz farkettiysen burada kaydetme savechanges yok

        public AboutManager(IAboutDal aboutDal)
        {
            _aboutDal = aboutDal;
        } //ıaboutdal ile nesne üretme silme cart curt için bir constructor ihtiyac var Bu constructor sayesinde AboutManager, IAboutDal’a erişebilir.

       // Dependency Injection(Bağımlılık enjeksiyonu) mantığıyla DAL katmanı dışarıdan verilir.

        public void TAdd(About t)
        {
            _aboutDal.Insert(t); //işte bu ve devamı klasik geliyor bu ı genericdala tanımladığımız ama generic repositoryde metotlarını yazdığımız şeyler
        }

        public void TDelete(About t)
        {
            _aboutDal.Delete(t);
        }

        public About TGetByID(int id)
        {
            return _aboutDal.GetByID(id);
        }

        public List<About> TGetList()
        {
           return  _aboutDal.GetList();
        }

        public void TUpdate(About t)
        {
            _aboutDal.Update(t);
        }
    }
}
