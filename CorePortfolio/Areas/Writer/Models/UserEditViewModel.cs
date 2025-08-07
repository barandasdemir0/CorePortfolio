namespace CorePortfolio.Areas.Writer.Models
{
    public class UserEditViewModel
    {
        public string? NameSurname { get; set; }
        public string? Password { get; set; }
        public string? ConfirmPassword { get; set; }
        public string? PictureUrl { get; set; }
        public IFormFile? Picture { get; set; }
    }
}
