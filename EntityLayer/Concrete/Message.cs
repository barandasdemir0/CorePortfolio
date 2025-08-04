using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Message
    {

        [Key]
        public int MessageID { get; set; }
        public string? MessageNameSurname { get; set; }
        public string? MessageMail { get; set; }
        public string? MessageContent { get; set; }
        public DateTime MessageDate { get; set; }
        public bool Status { get; set; }
    }
}
