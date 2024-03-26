using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Unicon.Filters;
using Unicon.Models;

namespace Unicon.Controllers;

[RedirectIfNotLoggedIn]
public class HomeController : Controller
{
   

    public IActionResult Index()
    {
        return View();
    }



}
