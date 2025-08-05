using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Portfolio
    {

        [Key]
        public int PortfolioID { get; set; }
        public string? ProjectName { get; set; }
        public string? ProjectImageUrl { get; set; }
        public string? ProjectImageUrl2 { get; set; }
        public string? Platform { get; set; }
        public string? Price { get; set; }
        public bool Status { get; set; }
        public int Value { get; set; }
        public string? ProjectUrl { get; set; }

    }
}
