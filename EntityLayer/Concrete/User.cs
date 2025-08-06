using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class User
    {
        [Key]
        public int UserID { get; set; }
        public string? UserNameSurname { get; set; }
        public string? Username { get; set; }
        public string? UserMail { get; set; }
        public string? UserPassword { get; set; }
        public string? UserImageUrl { get; set; }
        public bool Status { get; set; }

        public List<UserMessage>? UserMessages { get; set; }
    }
}
