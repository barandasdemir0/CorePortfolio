using System.ComponentModel.DataAnnotations;

namespace CorePortfolio.Areas.Writer.Models
{
    public class UserRegisterViewModel
    {
        [Required(ErrorMessage ="Lütfen Bu alanı Boş geçmeyiniz")]
        public string? UserName { get; set; }


        [Required(ErrorMessage ="Lütfen Bu alanı Boş geçmeyiniz")]
        public string? NameSurname { get; set; }

        [Required(ErrorMessage ="Lütfen Bu alanı Boş geçmeyiniz")]
        public string? ImageUrl { get; set; }


        [Required(ErrorMessage = "Lütfen Bu alanı Boş geçmeyiniz")]
        public string? Password { get; set; }


        [Required(ErrorMessage = "Lütfen Bu alanı Boş geçmeyiniz")]
        [Compare("Password",ErrorMessage ="Şifreler Uyuşmuyor")]
        public string? ConfirmPassword { get; set; }


        [Required(ErrorMessage = "Lütfen Bu alanı Boş geçmeyiniz")]
        public string? Mail { get; set; }
    }
}
