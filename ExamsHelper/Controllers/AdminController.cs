using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExamsHelper.Context;
using ExamsHelper.Services;
using Microsoft.AspNetCore.Mvc;


namespace ExamsHelper.Controllers
{
    public class AdminController : Controller
    {
        UserService uS;
        FacultyService fS;
        UniversityService unvS;
      

        public AdminController(dbcontext context)
        {
            uS = new UserService(context);
            fS = new FacultyService(context);
            unvS = new UniversityService(context);
        }

        public IActionResult Index()
        {
            if (uS.checkAdmRole(User.Identity.Name))
            {
                return View("Index");
            }
            return RedirectToAction("Index", "Home");
        }
    }
}
