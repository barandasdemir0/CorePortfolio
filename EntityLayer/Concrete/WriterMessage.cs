using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class WriterMessage
    {
        [Key]
        public int WriterMessageID { get; set; }
        public string? MessageSender { get; set; }
        public string? MessageReceiver { get; set; }
        public string? MessageSenderName { get; set; }
        public string? MessageReceiverName { get; set; }
        public string? MessageSubject { get; set; }
        public string? MessageContent { get; set; }
        public DateTime MessageDate { get; set; }
    }
}
