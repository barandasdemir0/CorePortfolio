using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class About
    {

        [Key]
        public int AboutID { get; set; }
        public string? AboutTitle { get; set; }
        public string? AboutDescription { get; set; }
        public string? PersonAge { get; set; }
        public string? PersonMail { get; set; }
        public string? PersonPhone { get; set; }
        public string? PersonAdress { get; set; }
        public string? ImageUrl { get; set; }
    }
}
