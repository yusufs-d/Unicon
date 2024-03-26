using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Unicon.Data
{
    public class Comment
    {
        [Key]
        public int CommentId { get; set; }

        [Required(ErrorMessage = "Yorum içeriği boş bırakılamaz!")]
        [Display(Name = "Yorum İçeriği")]
        public string? CommentContent { get; set; }

        [Required(ErrorMessage = "Lütfen puan verin!")]
        [Display(Name = "Puan")]
        [Range(0, 10, ErrorMessage = "Puan 0 ile 10 arasında olmalıdır.")]
        public int Point { get; set; }

        public int CommentType {get;set;}

        public int RelatedID {get;set;}

        public string? UserId {get; set;} 

        public virtual User? CommentedBy {get; set; } 

        public DateTime CreateDate{get;set;}
    }
}
