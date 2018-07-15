using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ExamsHelper.Models;
using ExamsHelper.Services;
using ExamsHelper.Context;
using Microsoft.AspNetCore.Authorization;

namespace ExamsHelper.Controllers
{
    public class HomeController : Controller
    {
        UserService uS;

        public HomeController(dbcontext context)
        {
            uS = new UserService(context);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public IActionResult SignUp([FromForm] User user)
        {                    
                uS.createUser(user);
                uS.Save();
            return View("Index");
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Registration()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
