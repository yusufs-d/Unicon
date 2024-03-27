using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using Unicon.Data;
using Unicon.Filters;
using Unicon.Models;

namespace Unicon.Controllers
{
    
    public class CourseController : Controller
    {

        private readonly DataContext _context;
        public CourseController(DataContext context)
        {
            _context = context;
        }

        [RedirectIfNotLoggedIn]
        public async Task<IActionResult> AllCourses()
        {

            var courses = await _context.Courses.Include(c => c.Instructor).ToListAsync();

            return View(courses);
        }

        [RedirectIfNotAdmin]
        public async Task<IActionResult> Create()
        {
            ViewBag.Instructors = new SelectList(await _context.Instructors.ToListAsync(), "InstructorId", "InstructorName");
            return View();
        }

        [RedirectIfNotAdmin]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Course model)
        {
            try{
            _context.Courses.Add(model);
            await _context.SaveChangesAsync();
            TempData["CreateSuccess"] = "Ders başarıyla oluşturuldu!";
            return RedirectToAction("ManageCourses");
            }catch{
            TempData["CreateError"] = "Ders oluşturulurken bir sorun oluştu";
            return View();
            }




        }


        [RedirectIfNotAdmin]
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

            ViewBag.Instructors = new SelectList(await _context.Instructors.ToListAsync(), "InstructorId", "InstructorName", course.InstructorId);


            return View(course);
        }

        [RedirectIfNotAdmin]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Course course)
        {
            if (id != course.CourseId)
            {
                return NotFound();
            }

            if(!ModelState.IsValid){
            TempData["EditError"] = "Ders güncellenirken bir sorun oluştu!";

                return View();
            }


            _context.Update(course);
            await _context.SaveChangesAsync();
            TempData["EditSuccess"] = "Ders başarıyla güncellendi!";
            return RedirectToAction("ManageCourses");

        }

        [RedirectIfNotAdmin]
        [HttpPost]
        public async Task<IActionResult> Delete([FromForm] int id)
        {
            
            var course = await _context.Courses.FindAsync(id);
            try{
                            if (course == null)
            {
                return NotFound();
            }
            _context.Courses.Remove(course);
            await _context.SaveChangesAsync();
            TempData["DeleteSuccess"] = "Ders başarıyla silindi!";
            return RedirectToAction("ManageCourses");
            }catch{
                TempData["DeleteError"] = "Ders silinirken bir hata ile karşılaşıldı!";
                return RedirectToAction("ManageCourses");
            }

        }


        [RedirectIfNotAdmin]
        public async Task<IActionResult> ManageCourses()
        {
            var courses = await _context.Courses
            .Include(c => c.Instructor)
            .ToListAsync();
            return View(courses);
        }

        [RedirectIfNotLoggedIn]
        [HttpGet]
        public async Task<IActionResult> CourseDetail(int? id)
        {
            var course = await _context.Courses.Include(c => c.Instructor).FirstOrDefaultAsync(c => c.CourseId == id);

            if (course == null)
            {
                return NotFound();
            }

            var comments = await _context.Comments.Where(c => c.RelatedID == id && c.CommentType == 0).ToListAsync();
            double totalPoints = comments.Sum(c => c.Point);
            int numberOfComments = comments.Count;

            double coursePoint = numberOfComments > 0 ? totalPoints / numberOfComments : 0;

            string formattedCoursePoint = coursePoint.ToString("0.0");

            double formattedCoursePointDouble = double.Parse(formattedCoursePoint);

            course.CoursePoint = formattedCoursePointDouble;

            await _context.SaveChangesAsync();

            var viewModel = new CourseDetailViewModel
            {
                Course = course,
                Comments = await _context.Comments.Where(c => c.RelatedID == id && c.CommentType == 0).Include(c => c.CommentedBy).ToListAsync()
            };

            return View(viewModel);
        }


    }
}