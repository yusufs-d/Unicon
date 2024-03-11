using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Unicon.Data;

namespace Unicon.Controllers
{
    public class AdminController : Controller
    {

        private readonly DataContext _context;
        

        public AdminController(DataContext context)
        {
            _context = context;
        }



    }
}