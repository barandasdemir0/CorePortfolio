using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class UserMessage
    {
        [Key]
        public int UserMessageID { get; set; }
        public string? Title { get; set; }
        public string? UserMessageContent { get; set; }
        public DateTime UserMessageDate { get; set; }
        public bool Status { get; set; }

        public int UserID { get; set; }
        public User? User { get; set; }
    }
}
