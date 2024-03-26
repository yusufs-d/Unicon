using System.ComponentModel.DataAnnotations;

namespace Unicon.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Kullanıcı adı gereklidir.")]
        [Display(Name = "Kullanıcı Adı")]
        public string? Username { get; set; }

        [Required(ErrorMessage = "Parola gereklidir.")]
        [DataType(DataType.Password)]
        [Display(Name = "Parola")]
        public string? Password { get; set; }




    }
}
