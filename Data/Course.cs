using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Unicon.Data
{
    public class Course
    {   
        [Key]
        public int LectureId { get; set; }


        [Required(ErrorMessage = "Ders kodu girmek zorunludur!")]
        public string? CourseCode { get; set; }

        [Required(ErrorMessage = "Ders ismi girmek zorunludur!")]
        public string? CourseName { get; set; }

        public int CoursePoint { get; set; }

        public int InstructorId {get; set; }
        public Instructor Instructor {get ; set; } = null!;
    }
}