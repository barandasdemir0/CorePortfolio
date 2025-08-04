using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Experience
    {
        public int ExperienceID { get; set; }
        public string? ExperienceName { get; set; }
        public string? ExperienceDescription { get; set; }
        public DateTime ExperienceDate { get; set; }
        public string? ExperienceImageUrl { get; set; }
    }
}
 