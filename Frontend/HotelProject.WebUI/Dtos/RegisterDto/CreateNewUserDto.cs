using System.ComponentModel.DataAnnotations;

namespace HotelProject.WebUI.Dtos.RegisterDto
{
    public class CreateNewUserDto
    {
        [Required(ErrorMessage = "Ad tələb olunur")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Soyad tələb olunur")]
        public string Surname { get; set; }
        [Required(ErrorMessage = "İstifadəçi adı tələb olunur")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Şifrə tələb olunur")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Şifrə təkrarı tələb olunur")]
        [Compare("Password", ErrorMessage = "Şifrələr uyğun gəlmir!")]
        public string ConfirmPassword { get; set; }
        [Required(ErrorMessage = "Email ünvanı tələb olunur")]
        public string Mail { get; set; }
    }
}
