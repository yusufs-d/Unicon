 using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Unicon.Data
{
    public class Instructor
    {
        [Key]
        public int InstructorId { get; set; }

        [StringLength(50, ErrorMessage = "Eğitmen ismi en fazla 50 karakter olmalıdır!")]
        [Required(ErrorMessage = "Eğitmen ismi girilmek zorunludur!")]
        [Display(Name = "Öğretim Elemanı Adı")]
        public string? InstructorName {get; set; }

        public double InstructorPoint  { get; set; }

        public ICollection<Course> CoursesGiven { get; set; } = new List<Course>();

    }
}