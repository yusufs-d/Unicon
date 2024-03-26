using Unicon.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Unicon.Filters;
using Unicon.Models;

namespace Unicon.Controllers
{
    public class InstructorController : Controller
    {
        private readonly DataContext _context;

        public InstructorController(DataContext context)
        {
            _context = context;
        }

        [RedirectIfNotLoggedIn]
        public async Task<IActionResult> AllInstructors()
        {

            var instructors = await _context.Instructors
             .Include(i => i.CoursesGiven)
             .ToListAsync();

            return View(instructors);
        }

        [RedirectIfNotAdmin]
        public async Task<IActionResult> Create()
        {
            ViewBag.Courses = new SelectList(await _context.Courses.ToListAsync(), "CourseId", "CourseCode");

            return View();
        }

        [RedirectIfNotAdmin]
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

        [RedirectIfNotAdmin]
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

        [RedirectIfNotAdmin]
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

        [RedirectIfNotAdmin]
        [HttpPost]
        public async Task<IActionResult> Delete([FromForm] int id)
        {
            var instructor = await _context.Instructors.Include(i=> i.CoursesGiven).FirstOrDefaultAsync(i=> i.InstructorId == id);
            if (instructor == null)
            {
                return NotFound();
            }
            
            if(instructor.CoursesGiven.Count > 0){
                TempData["DeleteError"] = "Silme hatası! Öğretim elemanı bir ya da birden fazla dersin öğretim elemanı olarak ayarlanmış. Silmek için öncelikle tüm derslerle ilişiğini kesin.";
                return RedirectToAction("ManageInstructors");

            }

            _context.Instructors.Remove(instructor);
            await _context.SaveChangesAsync();
            return RedirectToAction("ManageInstructors");
            
            
            

        }


        [RedirectIfNotAdmin]
        public async Task<IActionResult> ManageInstructors()
        {
            ViewBag.Courses = new SelectList(await _context.Courses.ToListAsync(), "CourseId", "CourseCode");

            var instructors = await _context.Instructors.ToListAsync();
            return View(instructors);
        }

        [RedirectIfNotLoggedIn]
        [HttpGet]
        public async Task<IActionResult> InstructorDetail(int? id)
        {
            var instructor = await _context.Instructors.Include(i => i.CoursesGiven).FirstOrDefaultAsync(i => i.InstructorId == id);

            if (instructor == null)
            {
                return NotFound();
            }

            var comments = await _context.Comments.Where(c => c.RelatedID == id && c.CommentType == 1).ToListAsync();

            double totalPoints = comments.Sum(c => c.Point);
            int numberOfComments = comments.Count;

            double coursePoint = numberOfComments > 0 ? totalPoints / numberOfComments : 0;

            string formattedCoursePoint = coursePoint.ToString("0.0");

            double formattedCoursePointDouble = double.Parse(formattedCoursePoint);

            instructor.InstructorPoint = formattedCoursePointDouble;

            await _context.SaveChangesAsync();

            var viewModel = new InstructorDetailViewModel
            {
                Instructor = instructor,
                Comments = await _context.Comments.Where(c => c.RelatedID == id && c.CommentType == 1).Include(c => c.CommentedBy).ToListAsync()
            };

            return View(viewModel);
        }

    }
}