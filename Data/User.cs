using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;

namespace Unicon.Data
{
    public class User : IdentityUser
    {
        [Display(Name = "Gerçek ad")]
        public string? RealName { get; set; }

        [Required(ErrorMessage = "Kullanıcı adı girmek zorunludur!")]
        [StringLength(20, ErrorMessage = "Kullanıcı adı 20 karakterden uzun olamaz!")]
        [Display(Name = "Kullanıcı adı")]
        override public string? UserName { get; set; }


        [Phone(ErrorMessage = "Lütfen uygun formatta telefon numarası giriniz!")]
        [Display(Name = "Telefon Numarası")]
        public new string? PhoneNumber { get; set; }

        [Required]
        public DateTime CreateDate { get; set; }

        [Required]
        public bool IsActive { get; set; }
    }
}
