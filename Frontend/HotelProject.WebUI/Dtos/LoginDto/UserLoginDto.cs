using System.ComponentModel.DataAnnotations;

namespace HotelProject.WebUI.Dtos.LoginDto
{
    public class UserLoginDto
    {
        [Required(ErrorMessage = "Email ünvanı tələb olunur!")]
        [EmailAddress(ErrorMessage = "Doğru olmayan email ünvanı")]
        public string Email { get; set; }
      
        [Required(ErrorMessage = "Şifrə tələb olunur")]
        public string Password { get; set; }
    }
}
