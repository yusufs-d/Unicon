using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Unicon.Data;

namespace Unicon.Controllers
{
    public class CourseController : Controller
    {
      
        private readonly DataContext _context;
        public CourseController(DataContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> AllCourses(){

            var courses = await _context.Courses.ToListAsync();

            return View(courses);
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.Instructors = new SelectList(await _context.Instructors.ToListAsync(), "InstructorId","InstructorName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Course model)
        {
            _context.Courses.Add(model);
            await _context.SaveChangesAsync();
            return RedirectToAction("AllCourses");
        }

   
    }
}