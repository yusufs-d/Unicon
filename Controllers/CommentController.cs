using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Unicon.Data;
using Unicon.Filters;
using Unicon.Models;

namespace Unicon.Controllers
{
    public class CommentController : Controller
    {
        private readonly DataContext _context;
        private readonly UserManager<User> _userManager;

        public CommentController(DataContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;

        }


        [RedirectIfNotLoggedIn]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CommentViewModelBase viewModel, int? commentType)
        {
            if (commentType == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(User);
                if (user != null && viewModel.CommentToAdd != null)
                {
                    var existingComment = await _context.Comments.FirstOrDefaultAsync(c => c.RelatedID == viewModel.CommentToAdd.RelatedID && c.UserId == user.Id);

                    if (existingComment != null)
                    {
                        ModelState.AddModelError("", "Kullanıcı daha önce yorum yapmış!");
                        var errorMessagesForExistingComment = ModelState.Values
                            .SelectMany(v => v.Errors)
                            .Select(e => e.ErrorMessage)
                            .ToList();

                        TempData["ErrorMessages"] = errorMessagesForExistingComment.ToArray();
                        if (commentType == 0)
                        {
                            return RedirectToAction("CourseDetail", "Course", new { id = viewModel.CommentToAdd.RelatedID });
                        }
                        if (commentType == 1)
                        {
                            return RedirectToAction("InstructorDetail", "Instructor", new { id = viewModel.CommentToAdd.RelatedID });
                        }
                    }

                    _context.Comments.Add(new Comment()
                    {
                        CommentContent = viewModel.CommentToAdd.CommentContent,
                        Point = viewModel.CommentToAdd.Point,
                        CommentType = commentType.Value,
                        RelatedID = viewModel.CommentToAdd.RelatedID,
                        UserId = user.Id,
                        CreateDate = DateTime.UtcNow
                    });

                    await _context.SaveChangesAsync();

                    if (commentType == 0)
                    {
                        TempData["CreteSuccess"] = "Yorum Başarıyla Eklendi!";
                        return RedirectToAction("CourseDetail", "Course", new { id = viewModel.CommentToAdd.RelatedID });
                    }
                    if (commentType == 1)
                    {
                        TempData["CreteSuccess"] = "Yorum Başarıyla Eklendi!";

                        return RedirectToAction("InstructorDetail", "Instructor", new { id = viewModel.CommentToAdd.RelatedID });
                    }
                }
                return NotFound();
            }

            var errorMessagesForCreateComment = ModelState.Values
                .SelectMany(v => v.Errors)
                .Select(e => e.ErrorMessage)
                .ToList();

            TempData["ErrorMessages"] = errorMessagesForCreateComment.ToArray();

            if (viewModel.CommentToAdd == null)
            {
                return NotFound();
            }

            if (commentType == 0)
            {
                return RedirectToAction("CourseDetail", "Course", new { id = viewModel.CommentToAdd.RelatedID });
            }
            if (commentType == 1)
            {
                return RedirectToAction("InstructorDetail", "Instructor", new { id = viewModel.CommentToAdd.RelatedID });
            }

            return NotFound();
        }


        [RedirectIfNotAdmin]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {

                return NotFound();
            }

            var comment = await _context.Comments.FindAsync(id);


            if (comment == null)
            {
                return NotFound();


            }

            var commentType = comment.CommentType;
            var relatedId = comment.RelatedID;

            _context.Comments.Remove(comment);
            await _context.SaveChangesAsync();
            if (commentType == 0)
            {
                TempData["DeleteSuccess"] = "Yorum başarıyla silindi!";
                return RedirectToAction("CourseDetail", "Course", new { id = relatedId });

            }

            if (commentType == 1)
            {
                TempData["DeleteSuccess"] = "Yorum başarıyla silindi!";
                return RedirectToAction("InstructorDetail", "Instructor", new { id = relatedId });

            }



            return RedirectToAction("Index", "Home");



        }






    }


}