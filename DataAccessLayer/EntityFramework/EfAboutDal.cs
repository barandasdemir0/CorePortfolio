using DataAccessLayer.Abstract;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfAboutDal:GenericRepository<About>,IAboutDal // generic repositoryde zaten ne olacak biliyoruz  metotlarımız ekle sil güncelle işlemi oluyor ve bunu about özelinde çağırdık ıaboutdal da metotlara özgü bir imzalama yapacağız örnek abouta özel durumlarını aktif pasif yap diyoruz ıabout dalda imzasını oluşturuyoruz burada da işlemini yapıyoruz
    {
    }
}
