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

               var instructors = await _context.Instructors
                .Include(i => i.CoursesGiven)
                .ToListAsync();

            return View(instructors);
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.Courses = new SelectList(await _context.Courses.ToListAsync(), "CourseId","CourseCode");

            return View();
        }

[HttpPost]
[ValidateAntiForgeryToken]
public async Task<IActionResult> Create(Instructor model, int[] CoursesGiven)
{
    if (ModelState.IsValid)
    {
        _context.Instructors.Add(model);
        await _context.SaveChangesAsync();

        if (CoursesGiven != null)
        {
            foreach (var courseId in CoursesGiven)
            {
                var course = await _context.Courses.FindAsync(courseId);
                if (course != null)
                {
                    model.CoursesGiven.Add(course);
                }
            }
            await _context.SaveChangesAsync();
        }

        return RedirectToAction("ManageInstructors"); 
    }

    return View(model);
}

   [HttpGet]
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var instructor = await _context.Instructors.FindAsync(id);

        if (instructor == null)
        {
            return NotFound();
        }

        return View(instructor);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, Instructor instructor)
    {
        if (id != instructor.InstructorId)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(instructor);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Instructors.Any(e => e.InstructorId == id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction("ManageInstructors");
        }
        return View(instructor);
    }

    [HttpPost]
    public async Task<IActionResult> Delete([FromForm]int id)
    {
        var kurs = await _context.Instructors.FindAsync(id);
        if(kurs == null)
        {
            return NotFound();
        }
        _context.Instructors.Remove(kurs);
        await _context.SaveChangesAsync();
        return RedirectToAction("ManageInstructors");
    }


public  async Task<IActionResult> ManageInstructors(){
    ViewBag.Courses = new SelectList(await _context.Courses.ToListAsync(), "CourseId","CourseCode");

    var instructors = await _context.Instructors.ToListAsync();
    return View(instructors);
}

    }
}