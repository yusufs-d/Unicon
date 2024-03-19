using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
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

    [HttpGet]
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var course = await _context.Courses.FindAsync(id);

        if (course == null)
        {
            return NotFound();
        }

        ViewBag.Instructors = new SelectList(await _context.Instructors.ToListAsync(), "InstructorId","InstructorName",course.InstructorId);


        return View(course);
    }

[HttpPost]
[ValidateAntiForgeryToken]
public async Task<IActionResult> Edit(int id, Course course)
{
    if (id != course.CourseId)
    {
        return NotFound();
    }

 
        _context.Update(course);
        await _context.SaveChangesAsync();
        return RedirectToAction("ManageCourses");

}

    [HttpPost]
    public async Task<IActionResult> Delete([FromForm]int id)
    {
        var course = await _context.Courses.FindAsync(id);
        if(course == null)
        {
            return NotFound();
        }
        _context.Courses.Remove(course);
        await _context.SaveChangesAsync();
        return RedirectToAction("ManageCourses");
    }

    

        public async Task<IActionResult> ManageCourses(){
            var courses = await _context.Courses
            .Include(c => c.Instructor)
            .ToListAsync();
            return View(courses);
        }

   
    }
}