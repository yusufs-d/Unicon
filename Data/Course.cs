using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Unicon.Data
{
    public class Course
    {   
        [Key]
        public int CourseId { get; set; }


        [Required(ErrorMessage = "Ders kodu girmek zorunludur!")]
        [Display(Name = "Kurs Kodu")]
        public string? CourseCode { get; set; }

        [Required(ErrorMessage = "Ders ismi girmek zorunludur!")]
        [Display(Name = "Kurs Adı")]
        public string? CourseName { get; set; }

        public int CoursePoint { get; set; }

        public int InstructorId {get; set; }

        [Display(Name ="Öğretim Elemanı")]
        public Instructor Instructor {get ; set; } = null!;
    }
}