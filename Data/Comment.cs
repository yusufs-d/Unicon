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
        public string? CommentContent { get; set; }

        [Required(ErrorMessage = "Lütfen puan verin!")]
        public int Point { get; set; }
        public int EntityId {get; set;}
        public virtual Entity? EntityType {get; set;}

        public int UserId {get; set;}

        public virtual User? CommentedBy {get; set; }

        
    }
}