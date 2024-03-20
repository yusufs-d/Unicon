using System.ComponentModel.DataAnnotations;

namespace Unicon.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Kullanıcı adı gereklidir.")]
        [StringLength(20, MinimumLength = 4, ErrorMessage = "Kullanıcı adı en az 4, en fazla 20 karakter olmalıdır.")]
        [Display(Name = "Kullanıcı Adı")]
        public string? Username { get; set; }

        [Required(ErrorMessage = "Gerçek isim gereklidir.")]
        [StringLength(50, ErrorMessage = "Gerçek isim en fazla 50 karakter olmalıdır.")]
        [Display(Name = "Gerçek İsim")]
        public string? RealName { get; set; }

        [Required(ErrorMessage = "E-posta adresi gereklidir.")]
        [EmailAddress(ErrorMessage = "Geçerli bir e-posta adresi giriniz.")]
        [Display(Name = "E-posta")]
        public string? Email { get; set; }

        [Phone(ErrorMessage = "Geçerli bir telefon numarası giriniz.")]
        [Required(ErrorMessage = "Telefon Numarası Gereklidir")]
        [Display(Name = "Telefon Numarası")]
        public string? PhoneNumber { get; set; }

        [Required(ErrorMessage = "Parola gereklidir.")]
        [StringLength(100, ErrorMessage = "{0} en az {2} ve en fazla {1} karakter uzunluğunda olmalıdır.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Parola")]
        public string? Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Parolayı Onayla")]
        [Compare("Password", ErrorMessage = "Parola ile parola onayı eşleşmiyor.")]
        public string? ConfirmPassword { get; set; }
    }
}
