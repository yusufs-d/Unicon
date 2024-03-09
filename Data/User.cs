using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.ComponentModel;

namespace Unicon.Data
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Display(Name = "Gerçek ad")]
        public string? RealName { get; set; }

        [Required(ErrorMessage = "Kullanıcı adı girmek zorunludur!")]
        [StringLength(20,ErrorMessage =("Kullanıcı adı 20 karakterden uzun olamaz!"))]
        [Display(Name = "Kullanıcı adı")]
        public string? Username { get; set; }

        [Required(ErrorMessage = "Eposta adresi girmek zorunludur!")]
        [EmailAddress(ErrorMessage = "Lütfen geçerli formatta bir eposta adresi giriniz!")]
        [Display(Name = "Eposta adresi")]
        public string? Email {get; set;}

        [Required(ErrorMessage = "Parola girmen zorunludur!")]
        [PasswordPropertyText]
        [Display(Name ="Parola")]
        public string? Password {get; set;}

        [Phone(ErrorMessage = "Lüften uygun formatta telefon numarası giriniz!")]
        [Display(Name = "Telefon Numarası")]
        public string? PhoneNumber {get;set;}

        [Required]
        public DateTime CreateDate {get;set;}

        [Required]
        public bool isActive {get;set;}


        
    }
}