using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IAboutService:IGenericService<About> // ekle sil güncelle cart curt işlemlerinide burada yapıyoruz yani ı genericdeki metotlarımızı imzaladik ve about için kullancaz
    {
    }
}
