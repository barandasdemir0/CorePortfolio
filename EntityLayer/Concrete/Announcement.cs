using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Announcement
    {

        [Key]
        public int AnnouncementID { get; set; }
        public string? AnnouncementTitle { get; set; }
        public string? AnnouncementContent { get; set; }
        public DateTime AnnouncementDate { get; set; }
        public string? AnnouncementStatus { get; set; }

    }
}
