using Unicon.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Unicon.Controllers
{
    public class InstructorController : Controller
    {
        private readonly DataContext _context;

        public InstructorController(DataContext context)
        {
            _context = context;
        }


        public async Task<IActionResult> AllInstructors(){

            var instructors = await _context.Instructors.ToListAsync();

            return View(instructors);
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.Courses = new SelectList(await _context.Courses.ToListAsync(), "CourseId","CourseCode");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Instructor model)
        {
            _context.Instructors.Add(model);
            await _context.SaveChangesAsync();
            return RedirectToAction("AllInstructors");
        }
    }
}